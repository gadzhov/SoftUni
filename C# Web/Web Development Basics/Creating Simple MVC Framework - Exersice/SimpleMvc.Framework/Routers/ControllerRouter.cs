namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Helpers;
    using Framework.Attributes.Methods;
    using Framework.Contracts;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Exceptions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private object controllerInstance;
        private string controllerName;
        private string actionName;
        private object[] methodParameters;

        public IHttpResponse Handle(IHttpRequest request)
        {
            try
            {
                this.getParameters = new Dictionary<string, string>(request.UrlParameters);
                this.postParameters = new Dictionary<string, string>(request.FormData);
                this.requestMethod = request.Method.ToString().ToUpper();

                this.PrepareControllerAndActionNames(request);

                MethodInfo methodInfo = this.GetActionForExecution();
                if (methodInfo == null)
                {
                    return new NotFoundResponse();
                }

                this.PrepareMethodParameters(methodInfo);

                IInvocable actionResult = methodInfo.Invoke(
                    this.GetControllerInstance(), this.methodParameters) as IInvocable;

                string content = actionResult.Invoke();

                return new ContentResponse(HttpStatusCode.Ok, content);
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
        }

        private void PrepareControllerAndActionNames(IHttpRequest request)
        {
            string[] pathParts = request.Path.Split(new[] {'/', '?'}, StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                return;
            }

            this.controllerName = $"{pathParts[0].Capitaliza()}{MvcContext.Get.ControllersSuffix}";
            this.actionName = pathParts[1].Capitaliza();
        }

        private MethodInfo GetActionForExecution()
        {
            foreach (MethodInfo method in this.GetSuitableMethods())
            {
                IEnumerable<HttpMethodAttribute> httpMethodAttributes = method
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!httpMethodAttributes.Any() && this.requestMethod == "GET")
                {
                    return method;
                }

                foreach (HttpMethodAttribute httpMethodAttribute in httpMethodAttributes)
                {
                    if (httpMethodAttribute.IsValid(this.requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            object controller = this.GetControllerInstance();

            if (controller == null)
            {
                return  new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private object GetControllerInstance()
        {
            string controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            Type controllerType = Type.GetType(controllerFullQualifiedName);

            if (controllerType == null)
            {
                return null;
            }

            this.controllerInstance = Activator.CreateInstance(controllerType);

            return this.controllerInstance;
        }

        private void PrepareMethodParameters(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            this.methodParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];

                if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
                {
                    string getParameterValue = this.getParameters[parameter.Name];

                    object value = Convert.ChangeType(
                        getParameterValue, parameter.ParameterType);

                    this.methodParameters[i] = value;
                }
                else
                {
                    Type modelType = parameter.ParameterType;

                    object modelInstance = Activator.CreateInstance(modelType);

                    PropertyInfo[] modelProperties = modelType.GetProperties();

                    foreach (PropertyInfo modelProperty in modelProperties)
                    {
                        string postParameterValue = this.postParameters[modelProperty.Name];

                        object value = Convert.ChangeType(postParameterValue, modelProperty.PropertyType);

                        modelProperty.SetValue(
                            modelInstance, 
                            value);
                    }

                    this.methodParameters[i] = Convert.ChangeType(
                        modelInstance,
                        modelType);
                }
            }
        }

    }
}

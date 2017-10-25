namespace SimpleMvc.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using Contracts;
    using Contracts.Generic;
    using Helpers;
    using ViewEngine.Generic;
    using ViewEngine;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string viewFullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            string fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }
    }
}

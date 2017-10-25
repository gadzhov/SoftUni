namespace SimpleMvc.Framework.Helpers
{
    public static class ControllerHelpers
    {
        public static string GetControllerName(object controller) => controller.GetType()
            .Name
            .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        public static string GetViewFullQualifiedName(string controller, string action) => string.Format(
            "{0}.{1}.{2}.{3}, {0}",
            MvcContext.Get.AssemblyName,
            MvcContext.Get.ViewsFolder,
            controller,
            action);
    }
}

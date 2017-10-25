namespace SimpleMvc.Framework.ViewEngine
{
    using System;
    using Contracts;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifiedName)
        {
            this.Action = Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName)) as IRenderable;
        }

        public IRenderable Action { get; set; }

        public string Invoke() => this.Action.Render();
    }
}

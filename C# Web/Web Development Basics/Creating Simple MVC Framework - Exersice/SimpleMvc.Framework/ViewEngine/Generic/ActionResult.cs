namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using System;
    using Contracts.Generic;

    public class ActionResult<TModel> : IActionResult<TModel>
    {
        public ActionResult(string viewFullQualifiedName, TModel model)
        {
            this.Action = Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName)) as IRenderable<TModel>;
            this.Action.Model = model;
        }

        public IRenderable<TModel> Action { get; set; }

        public string Invoke() => this.Action.Render();
    }
}

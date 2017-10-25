namespace SimpleMvc.Framework.Contracts.Generic
{
    using SimpleMvc.Framework.Contracts;

    public interface IActionResult<TModel> : IInvocable
    {
        IRenderable<TModel> Action { get; set; }
    }
}

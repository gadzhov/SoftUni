namespace SimpleMvc.Framework.Contracts
{
    using Framework.Contracts;

    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}

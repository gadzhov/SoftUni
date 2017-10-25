namespace SimpleMvc.Framework.Contracts.Generic
{
    using SimpleMvc.Framework.Contracts;

    public interface IRenderable<TModel> : IRenderable
    {
        TModel Model { get; set; }
    }
}

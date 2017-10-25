namespace SimpleMvc.App.Views.Home
{
    using Framework.Contracts;

    public class Index : IRenderable
    {
        public string Render() => "<h1>Test</h1>";
    }
}

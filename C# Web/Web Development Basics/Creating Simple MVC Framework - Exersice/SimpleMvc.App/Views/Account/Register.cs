namespace SimpleMvc.App.Views.Account
{
    using SimpleMvc.Framework.Contracts;

    public class Register : View, IRenderable
    {
        public string Render()
        {
            return this.GetHtml("Account/register");
        }
    }
}

namespace SimpleMvc.App.Views
{
    using System.IO;

    public abstract class View
    {
        private string Html { get; set; }

        protected string GetHtml(string path)
        {
            this.Html = File.ReadAllText($@"../SimpleMvc.App/Views/{path}.html");

            return this.Html;
        }
    }
}

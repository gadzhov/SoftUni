namespace WebServer.Application.Views
{
    using System.Text;
    using WebServer.Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<head>")
                .AppendLine("<title>By the Cake</title>")
                .AppendLine("<meta charset=\"UTF-8\">")
                .AppendLine("<meta name=\"description\" content=\"Buy the cake in By the Cake\">")
                .AppendLine("<meta name=\"keywords\" content=\"cakes, buy\">")
                .AppendLine("<meta name=\"author\" content=\"Vladimir Gadjov\">")
                .AppendLine("<style>")
                .AppendLine("footer p { text-align: center; } pre {background-color: #F94F80;}")
                .AppendLine("</style>")
                .AppendLine("<h1>By The Cake</h1>")
                .AppendLine("<h2>Enjoy our awesome cakes</h2>")
                .AppendLine("<hr/>")
                .AppendLine("<ul>")
                .AppendLine("<li><a href=\"#\">Home</a>")
                .AppendLine("<ol>")
                .AppendLine("<li><a href=\"#cakes\">Our Cakes</a></li>")
                .AppendLine("<li><a href=\"#stores\">Our Stores</li>")
                .AppendLine("</ol></li>")
                .AppendLine("<li><a href=\"add\">Add Cake</a></li>")
                .AppendLine("<li><a href=\"search\">Browse Cakes</a></li>")
                .AppendLine("<li><a href=\"#aboutus\">About Us</a></li>")
                .AppendLine("</ul>")
                .AppendLine("<h2>Home</h2>")
                .AppendLine("<h3 id=\"cakes\">Our Cakes</h3>")
                .AppendLine(
                    "<p><strong><em>Cake</em></strong> is a form of <strong><em>sweet dessert</em></strong> that is typically baked. In its oldest forms, cakes were modifications of breads, but cakes now cover a wide range of preparations that can be simple or elaborate, and that share features with other desserts such as pastries, meringues, custards, and pies.</p>")
                .AppendLine("<img src=\"http://wallpapercave.com/wp/63hB3f3.jpg\" width=\"200\"/>")
                .AppendLine("<h3 id=\"stores\">Our Stores</h3>")
                .AppendLine(
                    "<p>Our stores are located in 21 cities all over the world. Come and see what we have for you.</p>")
                .AppendLine("<img src=\"https://i.ytimg.com/vi/aryWey6TQF0/maxresdefault.jpg\" width=\"200\"/>")
                .AppendLine("<h3 id=\"aboutus\">About Us</h3>")
                .AppendLine("<dl>")
                .AppendLine("<dt>By the Cake Ltd.</dt>")
                .AppendLine("<dd>Company Name</dd>")
                .AppendLine("<dt>John Smith</dt>")
                .AppendLine("<dd>Owner</dd>")
                .AppendLine("</dl>")
                .AppendLine("<pre>")
                .AppendLine("City: Hong Kong\t\tCity: Salzburg")
                .AppendLine("Address: ChoCoLad 18\tAddress: SchokoLeiden 73")
                .AppendLine("Phone: +78952804429\tPhone: +49241432990")
                .AppendLine("</pre>")
                .AppendLine("<footer>")
                .AppendLine("<hr/>")
                .AppendLine("<p style=\"text-align:center\">&copy;All Rights Reserved.</p>")
                .AppendLine("</footer>");

            return sb.ToString();
        }
    }
}

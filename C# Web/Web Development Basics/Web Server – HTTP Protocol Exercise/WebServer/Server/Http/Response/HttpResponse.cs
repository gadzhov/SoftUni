namespace WebServer.Server.Http.Response
{
    using System.Text;
    using Contracts;
    using Server.Contracts;
    using HttpStatusCode = Enums.HttpStatusCode;

    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;

        protected HttpResponse(string redirectUrl)
        {
            this.HttpHeaderCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.HttpHeaderCollection = new HttpHeaderCollection();
            this.StatusCode = responseCode;
            this.view = view;
        }

        private HttpHeaderCollection HttpHeaderCollection { get; set; }

        private HttpStatusCode StatusCode { get; set; }

        private string StatusMessage => this.StatusCode.ToString();

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();
                response.AppendLine($"HTTP/1.1 {(int) this.StatusCode} {this.StatusMessage}");
                response.AppendLine($"{this.HttpHeaderCollection}");
                response.AppendLine();

                if ((int) this.StatusCode < 300 || (int) this.StatusCode > 400)
                {
                    response.AppendLine(this.view.View());
                }

                return response.ToString();
            }
        }

        public void AddHeader(string key, string value)
        {
            this.HttpHeaderCollection.Add(new HttpHeader(key, value));
        }
    }
}

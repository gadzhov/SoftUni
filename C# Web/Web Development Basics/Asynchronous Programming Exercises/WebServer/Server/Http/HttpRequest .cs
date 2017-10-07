namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Enums;
    using Contracts;
    using Exceptions;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameter = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public HttpCookieCollection CookieCollection { get; private set; }

        public HttpSession HttpSession { get; set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameter { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameters(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string[] requestLine = requestLines
                .First()
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine.Last().ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine.First().ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)
                .First();
            this.ParseHeaders(requestLines);
            this.ParseCookies();
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split("?")[1];
            this.ParseQuery(query, this.QueryParameter);
        }

        private void ParseQuery(string query, Dictionary<string, string> dict)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');
            foreach (var queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split('=');
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                dict.Add(WebUtility.UrlDecode(queryArgs[0]), WebUtility.UrlDecode(queryArgs[1]));
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            string[] headersLines = requestLines.Skip(1).ToArray();

            foreach (var headerLine in headersLines)
            {
                string[] headerArgs = headerLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                if (headerArgs.Length != 2)
                {
                    continue;
                }
                string key = headerArgs[0];
                string value = headerArgs[1];

                HttpHeader httpHeader = new HttpHeader(key, value);

                this.HeaderCollection.Add(httpHeader);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Headers must contain \"Host\"");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string toUpper)
        {
            Enum.TryParse(toUpper, out HttpRequestMethod httpRequestMethod);

            return httpRequestMethod;
        }

        private void ParseCookies()
        {
            if (this.HeaderCollection.ContainsKey("Cookie"))
            {
                ICollection<HttpHeader> cookiesList = this.HeaderCollection.GetHeader("Cookie");

                foreach (HttpHeader header in cookiesList)
                {
                    string cookieString = header.Value;
                    if (string.IsNullOrEmpty(cookieString))
                    {
                        return;
                    }

                    string[] cookies = cookieString.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                    if (!cookies.Any())
                    {
                        return;
                    }

                    foreach (string c in cookies)
                    {
                        if (!c.Contains("="))
                        {
                            continue;
                        }
                        string[] cookieValuePair = c.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);

                        if (cookieValuePair.Length == 2)
                        {
                            string key = cookieValuePair[0];
                            string value = cookieValuePair[1];

                            HttpCookie cookie = new HttpCookie(key, value, false);

                            this.CookieCollection.Add(cookie);
                        }
                    }
                }
            }
        }

        public void SetSession(Dictionary<string, HttpSession> session)
        {
            if (this.CookieCollection.ContainsKey("sessionId"))
            {
                var sessionCookie = this.CookieCollection.Get("sessionId");
                string sessionId = sessionCookie.Value;
                if (session.ContainsKey(sessionId))
                    this.HttpSession = session[sessionId];
            }
        }
    }
}

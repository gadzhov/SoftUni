namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using Http.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            this.headers[header.Key] = header;
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (this.ContainsKey(key))
            {
                return this.headers[key];
            }

            throw new InvalidOperationException("Invalid key!");
        }

        public override string ToString() => string.Join(Environment.NewLine, this.headers.Values);
    }
}

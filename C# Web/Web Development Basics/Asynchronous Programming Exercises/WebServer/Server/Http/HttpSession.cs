namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;

    public class HttpSession
    {
        private readonly Dictionary<string, string> parameters;

        public HttpSession(string id)
        {
            this.parameters = new Dictionary<string, string>();
            this.Id = id;
        }

        public string Id { get; private set; }

        public string GetParameters(string key)
        {
            if (!this.parameters.ContainsKey(key))
            {
                return null;
            }

            return this.parameters[key];
        }

        public void Add(string key, string value) => this.parameters[key] = value;

        public void Clear() => this.parameters.Clear();

        public bool Contains(string key) => this.parameters.ContainsKey(key);
    }
}

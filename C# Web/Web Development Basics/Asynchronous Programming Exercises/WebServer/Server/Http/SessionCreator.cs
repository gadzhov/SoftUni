namespace WebServer.Server.Http
{
    using System;

    public class SessionCreator
    {
        private Random random;
        private static SessionCreator sessionCreator;

        private SessionCreator()
        {
            this.random = new Random();
        }

        public static SessionCreator GetInstance()
        {
            if (sessionCreator == null)
                sessionCreator = new SessionCreator();
            return sessionCreator;
        }

        public string GenerateSessionId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}

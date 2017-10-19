namespace MyCoolWebServer.Server.Http
{
    using System.Collections.Concurrent;

    public static class SessionStore
    {
        public const string SessionCookieKey = "MY_SID";
        public const string CurrentUserKey = "^%Current_User_Session_Key%^";
        public const string CurrentUserAuthorization = "^%Current_User_Authorization%^";
        public const string TempGames = "^%Temp_Games%^";

        private static readonly ConcurrentDictionary<string, HttpSession> sessions =
            new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession Get(string id)
            => sessions.GetOrAdd(id, _ => new HttpSession(id));
    }
}

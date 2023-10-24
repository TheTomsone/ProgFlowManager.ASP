namespace ProgFlowManager.ASP.Tools
{
    public static class SessionExtension
    {
        public static void SetBool(this ISession session, string key, bool value)
        {
            session.SetString(key, value ? "true" : "false");
        }
        public static bool GetBool(this ISession session, string key)
        {
            return session.GetString(key) == "true";
        }
    }
}

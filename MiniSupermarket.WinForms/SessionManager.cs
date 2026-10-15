namespace MiniSupermarket.WinForms
{
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentUsername { get; set; } = "admin01";
        public static string CurrentRole { get; set; } = "Admin";
    }
}

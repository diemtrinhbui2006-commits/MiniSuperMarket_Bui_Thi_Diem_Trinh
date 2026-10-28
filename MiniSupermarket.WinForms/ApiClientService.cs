using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MiniSupermarket.WinForms
{
    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri((Environment.GetEnvironmentVariable("MINISUPERMARKET_API_URL")
                ?? "https://localhost:7046/api/").TrimEnd('/') + "/", UriKind.Absolute),
            Timeout = TimeSpan.FromSeconds(30)
        };

        public static HttpClient Client
        {
            get
            {
                // Luôn đồng bộ, kể cả khi đăng xuất để xóa Bearer token cũ.
                SetAuthorization(SessionManager.JwtToken);
                return _client;
            }
        }

        public static void AttachToken(string? token)
        {
            SessionManager.JwtToken = token?.Trim() ?? string.Empty;
            SetAuthorization(SessionManager.JwtToken);
        }

        private static void SetAuthorization(string? token)
        {
            _client.DefaultRequestHeaders.Authorization = string.IsNullOrWhiteSpace(token)
                ? null
                : new AuthenticationHeaderValue("Bearer", token.Trim());
        }
    }
}

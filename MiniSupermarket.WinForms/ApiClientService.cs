using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MiniSupermarket.WinForms
{
    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7046/api/")
        };

        public static HttpClient Client
        {
            get
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    _client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                }
                return _client;
            }
        }
    }
}

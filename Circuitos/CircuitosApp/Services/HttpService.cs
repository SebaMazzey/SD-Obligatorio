using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CircuitosApp.Services
{
    public static class HttpService
    {
        private static readonly HttpClient client = new();
        private static readonly string authHeader = "Auth-Token";

        public enum RequestType
        {
            Get,
            Post
        }

        public static void AddBaseUrl(string baseUrl)
        {
            client.BaseAddress = new Uri(baseUrl);
        }

        public static string CallDepartmentApiAsync(string url, RequestType requestType, string authToken = "", object body = null)
        {

            if (authToken.Length != 0)
            {
                // Reset header value if already exists
                if (client.DefaultRequestHeaders.Contains(authHeader))
                    client.DefaultRequestHeaders.Remove(authHeader);
                client.DefaultRequestHeaders.Add(authHeader, authToken);
            }

            var response = "";
            try
            {
                switch (requestType)
                {
                    case RequestType.Get:
                        var httpResponse = client.GetAsync(url).GetAwaiter().GetResult();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                            response = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        break;
                    case RequestType.Post:
                        var jsonBody = body != null ? JsonConvert.SerializeObject(body): "";
                        HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                        httpResponse = client.PostAsync(url, content).GetAwaiter().GetResult();
                        if (httpResponse.IsSuccessStatusCode)
                            response = HttpStatusCode.OK.ToString();
                        else
                            response = String.Empty;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}

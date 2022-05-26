using System.Net.Http;
using Central.Core.Interfaces.Services;

namespace Central.Core.Services
{
    public class DepartmentClient : IDepartmentClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverBaseUrl;

        public DepartmentClient(HttpClient httpClient, string serverBaseUrl)
        {
            _httpClient = httpClient;
            _serverBaseUrl = serverBaseUrl;
        }
        
        
    }
}
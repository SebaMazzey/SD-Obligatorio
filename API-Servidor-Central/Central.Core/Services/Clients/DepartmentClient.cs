using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Central.Core.Interfaces.Services.Clients;
using Central.Core.Services.Dto;

namespace Central.Core.Services.Clients
{
    public class DepartmentClient : IDepartmentClient
    {
        private readonly HttpClient _client;
        private readonly string _departmentName;

        public DepartmentClient(HttpClient client, string departmentName)
        {
            _client = client;
            _departmentName = departmentName;
        }

        public async Task<DepartmentVoteResults> GetVoteResults()
        {
            var httpResponse = this._client.GetAsync("/Vote/Results").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var voteResults = await httpResponse.Content.ReadFromJsonAsync<VoteResults>();
                return new DepartmentVoteResults(_departmentName, voteResults);                
            }
            throw new Exception(
                "Unable to get department vote results in " + _departmentName + ": " + httpResponse.ReasonPhrase);
        }
    }
}
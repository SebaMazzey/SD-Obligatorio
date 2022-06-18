using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CircuitosApp.Services
{
    public class VoteService
    {
        public VoteService()
        {
        }

        public static List<string> GetVotingOptions()
        {
            try
            {
                var jsonResult = HttpService.CallDepartmentApiAsync("Option/Options", HttpService.RequestType.Get);
                List<VotingOption> options = JsonConvert.DeserializeObject<List<VotingOption>>(jsonResult);
                return options.Select(option => option.Name).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SubmitVote(string authToken, string selectedOption, string userCi, int circuitNumber)
        {
            try
            {
                var vote = new Vote
                {
                    Ci = userCi,
                    Option = selectedOption,
                    CircuitNumber = circuitNumber
                };
                var result = HttpService.CallDepartmentApiAsync("Vote/Add", HttpService.RequestType.Post, authToken, vote);
                return result == HttpStatusCode.OK.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private class VotingOption
        {
            public string Name { get; set; }
        }

        private class Vote
        {
            [JsonPropertyName("ci")]
            public string Ci { get; set; }
            [JsonPropertyName("option")]
            public string Option { get; set; }
            [JsonPropertyName("circuit_number")]
            [JsonProperty(PropertyName = "circuit_number")]
            public int CircuitNumber { get; set; }
        }
    }
}

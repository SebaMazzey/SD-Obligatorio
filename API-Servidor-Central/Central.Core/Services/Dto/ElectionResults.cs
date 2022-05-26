using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Central.Core.Services.Dto
{
    public class ElectionResults
    {
        [JsonPropertyName("summary")]
        public VoteResults Summary { get; set; }
        [JsonPropertyName("department_results")]
        public DepartmentsVoteResults DepartmentVoteResults { get; set; }
    }
}
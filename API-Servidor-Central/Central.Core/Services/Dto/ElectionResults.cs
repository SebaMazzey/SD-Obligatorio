using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Central.Core.Services.Dto
{
    /**
     * Resultados totales de la eleccion
     */
    public class ElectionResults
    {
        [JsonPropertyName("summary")]
        public VoteResults Summary { get; set; }
        [JsonPropertyName("department_results")]
        public CountryVoteResults DepartmentVoteResults { get; set; }
    }
}
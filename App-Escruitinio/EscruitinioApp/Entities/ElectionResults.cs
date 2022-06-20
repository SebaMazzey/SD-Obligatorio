using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EscruitinioApp.Entities
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

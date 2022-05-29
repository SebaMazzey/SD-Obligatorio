using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Departments_Core.Services.Dto
{
    public class Vote
    {
        [Required]
        [JsonPropertyName("ci")]
        public string Ci { get; set; }
        [Required]
        [JsonPropertyName("option")]
        public string Option { get; set; }
        [Required]
        [JsonPropertyName("circuit_number")]
        [JsonProperty(PropertyName = "circuit_number")]
        public int CircuitNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Departments_Core.Services.Dto
{
    public class Option
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

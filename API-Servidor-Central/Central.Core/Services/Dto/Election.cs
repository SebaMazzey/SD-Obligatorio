using System;
using System.Collections.Generic;

namespace Central.Core.Services.Dto
{
    public class Election
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}
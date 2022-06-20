using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscruitinioApp.Entities
{
    public class Election
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<string> Options { get; set; }
        public string ElectionDisplay { get; set; }
        public void LoadNameDisplay()
        {
            this.ElectionDisplay = Name + "    Inicio: " + StartDate.ToString("dd/MM/yyyy");
        }
    }
}

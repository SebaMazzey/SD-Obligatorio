using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class Circuit
    {
        public Circuit()
        {
            Votes = new HashSet<Vote>();
            EnabledDevices = new HashSet<EnabledDevice>();
        }

        [Key]
        public int Number { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<EnabledDevice> EnabledDevices { get; set; }
    }
}

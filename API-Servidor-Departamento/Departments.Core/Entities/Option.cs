using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class Option
    {
        public Option()
        {
            Votes = new HashSet<Vote>();
        }

        [Key]
        public string Name { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}

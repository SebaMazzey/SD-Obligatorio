using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class EnabledDevice
    {
        [Key]
        public string Code { get; set; }
        public int Circuit_Number { get; set; }

        public virtual Circuit Circuit { get; set; }
    }
}

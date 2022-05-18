using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class PersonEntity
    {
        [Key]
        public string Ci { get; set; }
        public bool Already_Voted { get; set; }
    }
}

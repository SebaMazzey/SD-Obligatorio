using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class Person
    {
        [Key]
        public string CI { get; set; }
        public bool AlreadyVoted { get; set; }
    }
}

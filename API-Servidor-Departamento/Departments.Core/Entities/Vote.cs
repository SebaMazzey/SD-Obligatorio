using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Circuit_Number { get; set; }
        public string Option_Name { get; set; }

        public virtual Option Option { get; set; }
        public virtual Circuit Circuit { get; set; }
    }
}

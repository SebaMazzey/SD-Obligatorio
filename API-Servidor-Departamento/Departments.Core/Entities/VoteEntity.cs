using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    [Table("Votes")]
    public class VoteEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("Circuit_Number")]
        public int CircuitNumber { get; set; }
        [Column("Option_Name")]
        public string OptionName { get; set; }
        public virtual OptionEntity Option { get; set; }
        public virtual CircuitEntity Circuit { get; set; }
    }
}

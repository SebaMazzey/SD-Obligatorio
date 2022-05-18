using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class VoteEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("circuit_number")]
        public int CircuitNumber { get; set; }
        [Column("option_name")]
        public string OptionName { get; set; }
        public virtual OptionEntity Option { get; set; }
        public virtual CircuitEntity Circuit { get; set; }
    }
}

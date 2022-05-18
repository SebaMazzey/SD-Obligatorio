using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class EnabledDeviceEntity
    {
        [Key]
        [Column("code")]
        public string Code { get; set; }
        [Column("circuit_number")]
        public int CircuitNumber { get; set; }
        public virtual CircuitEntity Circuit { get; set; }
    }
}

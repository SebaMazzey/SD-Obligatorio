using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    [Table("EnabledDevices")]
    public class EnabledDeviceEntity
    {
        [Key]
        [Column("Code")]
        public string Code { get; set; }
        [Column("Circuit_Number")]
        public int CircuitNumber { get; set; }
        public virtual CircuitEntity Circuit { get; set; }
    }
}

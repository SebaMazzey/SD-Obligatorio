using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class CircuitEntity
    {
        public CircuitEntity()
        {
            Votes = new HashSet<VoteEntity>();
            EnabledDevices = new HashSet<EnabledDeviceEntity>();
        }

        [Key]
        [Column("number")]
        public int Number { get; set; }
        public virtual ICollection<VoteEntity> Votes { get; set; }
        public virtual ICollection<EnabledDeviceEntity> EnabledDevices { get; set; }
    }
}

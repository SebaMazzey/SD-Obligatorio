using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class UserEntity
    {
        [Key]
        [Column("ci")]
        public string Ci { get; set; }
        [Column("already_voted")]
        public bool AlreadyVoted { get; set; }
    }
}

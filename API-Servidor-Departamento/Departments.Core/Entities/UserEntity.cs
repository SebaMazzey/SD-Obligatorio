using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [Column("CI")]
        public string Ci { get; set; }
        [Column("Already_Voted")]
        public bool AlreadyVoted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    [Table("Options")]
    public class OptionEntity
    {
        public OptionEntity()
        {
            Votes = new HashSet<VoteEntity>();
        }

        [Key]
        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<VoteEntity> Votes { get; set; }
    }
}

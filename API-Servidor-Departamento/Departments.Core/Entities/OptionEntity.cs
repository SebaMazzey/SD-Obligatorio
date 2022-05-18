using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    public class OptionEntity
    {
        public OptionEntity()
        {
            Votes = new HashSet<VoteEntity>();
        }

        [Key]
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<VoteEntity> Votes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Core.Entities
{
    [Table("Options")]
    public class OptionEntity
    {
        public OptionEntity()
        {
            DepartamentalVotes = new HashSet<DepartamentalVoteEntity>();
        }

        [Key, MaxLength(100)]
        public string Name { get; set; }
        public int TotalVotes { get; set; }

        [Column("Election_Id")]
        public int ElectionId { get; set; }
        public ElectionEntity Election { get; set; }
        public ICollection<DepartamentalVoteEntity> DepartamentalVotes { get; set; }
    }
}

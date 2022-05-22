using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Core.Entities
{
    [Table("DepartamentalVotes")]
    public class DepartamentalVoteEntity
    {
        [Column("Option_Name")]
        public string OptionName { get; set; }
        public OptionEntity Option { get; set; }

        [Column("Department_Name")]
        public string DepartmentName { get; set; }
        public DepartmentEntity Department { get; set; }

        public int VotesCount { get; set; }
    }
}

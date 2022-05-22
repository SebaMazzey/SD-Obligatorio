using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Core.Entities
{
    [Table("Election")]
    public class ElectionEntity
    {
        public ElectionEntity()
        {
            Options = new HashSet<OptionEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public ICollection<OptionEntity> Options { get; set; }
    }
}

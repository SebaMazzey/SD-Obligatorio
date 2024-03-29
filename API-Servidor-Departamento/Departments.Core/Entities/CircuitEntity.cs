﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Entities
{
    [Table("Circuits")]
    public class CircuitEntity
    {
        public CircuitEntity()
        {
            Votes = new HashSet<VoteEntity>();
        }

        [Key]
        public int Number { get; set; }
        public virtual ICollection<VoteEntity> Votes { get; set; }
    }
}

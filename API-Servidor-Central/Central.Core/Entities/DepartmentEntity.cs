﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.Core.Entities
{
    [Table("Departments")]
    public class DepartmentEntity
    {
        public DepartmentEntity()
        {
            DepartamentalVotes = new HashSet<DepartamentalVoteEntity>();
        }

        [Key, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<DepartamentalVoteEntity> DepartamentalVotes { get; set; }
    }
}

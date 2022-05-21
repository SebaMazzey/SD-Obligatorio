﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departments_Core.Services.Dto;

namespace Departments_Core.Interfaces.Services
{
    public interface IVoteService
    {
        void AddVote(Vote vote);
        void Commit();
    }
}

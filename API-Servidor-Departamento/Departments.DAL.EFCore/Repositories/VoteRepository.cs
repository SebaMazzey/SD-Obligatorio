using Departments.DAL.EFCore.Core;
using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments.DAL.EFCore.Repositories
{
    public class VoteRepository: EfRepository<VoteEntity>, IVoteRepository
    {
        public VoteRepository(DepartmentContext context) : base(context) { }
        
        public Dictionary<string, int> CountVotingResults()
        {
            return this._dbContext.Votes
                .GroupBy(v => v.OptionName)
                .Select(v => new {Option = v.Key, Count = v.Count() })
                .OrderByDescending(v => v.Count)
                .ToDictionary(r => r.Option, r => r.Count);
        }
    }
}

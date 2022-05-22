using Departments_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Interfaces.Repositories
{
    public interface IVoteRepository: IRepository<VoteEntity>
    {
        Dictionary<string, int> CountVotingResults();
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class ElectionRepository : EfRepository<ElectionEntity>, IElectionRepository
    {
        public ElectionRepository(CentralContext dbContext) : base(dbContext) { }

        public bool ElectionIsValid(int electionId)
        {
            return this._dbContext.Elections.Any(e => e.Id == electionId && e.EndDate < System.DateTime.Now);
        }
    }
}
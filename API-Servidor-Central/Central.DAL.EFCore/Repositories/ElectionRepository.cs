using System.Collections.Generic;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class ElectionRepository : EfRepository<ElectionEntity>, IElectionRepository
    {
        public ElectionRepository(CentralContext dbContext) : base(dbContext) { }
    }
}
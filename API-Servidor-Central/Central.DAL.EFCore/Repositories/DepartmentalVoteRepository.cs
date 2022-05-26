using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class DepartmentalVoteRepository : EfRepository<DepartmentalVoteEntity>, IDepartmentalVoteRepository
    {
        public DepartmentalVoteRepository(CentralContext dbContext) : base(dbContext)
        {
        }
    }
}
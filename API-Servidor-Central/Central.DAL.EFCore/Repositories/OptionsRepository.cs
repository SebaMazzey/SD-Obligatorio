using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class OptionsRepository : EfRepository<OptionEntity>, IOptionsRepository
    {
        public OptionsRepository(CentralContext dbContext) : base(dbContext)
        {
        }
    }
}
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class DepartmentRepository : EfRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(CentralContext dbContext) : base(dbContext)
        {
        }
    }
}
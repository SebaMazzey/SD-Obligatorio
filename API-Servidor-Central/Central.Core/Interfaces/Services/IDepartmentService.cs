using System.Threading.Tasks;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IDepartmentService
    {
        public Task<DepartmentsVoteResults> UpdateAllDepartmentVotes();
    }
}
using System.Threading.Tasks;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services.Clients
{
    public interface IDepartmentClient
    {
        public Task<DepartmentVoteResults> GetVoteResults();
    }
}
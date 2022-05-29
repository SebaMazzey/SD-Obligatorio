using System.Threading.Tasks;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IDepartmentService
    {
        /**
         * Se obtienen los resultados de votacion de cada departamento
         */
        public CountryVoteResults GetAllDepartmentVotes(int electionId, bool forceUpdate);
    }
}
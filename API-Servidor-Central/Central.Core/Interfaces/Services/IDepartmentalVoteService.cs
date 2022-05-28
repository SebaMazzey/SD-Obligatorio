using System.Threading.Tasks;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IDepartmentalVoteService
    {
        /**
         *  Persistir los nuevos resultados de un departamento
         */
        public Task UpdateDepartmentVotes(DepartmentVoteResults department);

        /**
         * Obtener los resultados ya persistidos en la base anteriormente
         */
        public DepartmentsVoteResults GetDepartmentVoteResults(int electionId);

        /**
         * Eliminar votos departamentales de una eleccion, utilizado para forzar u¿el actualizado de votos
         */
        void DeleteDepartamentalVotes(int electionId);
    }
}
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IElectionService
    {
        /**
         * Obtiene los votos de todos los departamentos, los procesa y actualiza en la base de datos.
         */
        public ElectionResults GetElectionResults(int electionId, bool forceUpdate = false);
    }
}
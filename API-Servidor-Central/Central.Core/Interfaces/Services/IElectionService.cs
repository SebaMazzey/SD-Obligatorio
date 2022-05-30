using System.Collections.Generic;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IElectionService
    {
        public void CreateElection(Election election);
        

        public IEnumerable<ElectionInfo> GetAllElections();
        
        /**
         * Obtiene los votos de todos los departamentos, los procesa y actualiza en la base de datos.
         */
        public ElectionResults GetElectionResults(int electionId, bool forceUpdate = false);
    }
}
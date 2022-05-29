using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IOptionsService
    {
        /**
         * Actualizar el conteo de votos totales del pais para cada Option
         * <param name="voteResults">Votos totales del pais de cada Option </param>
         */
        void UpdateCount(int electionId, VoteResults voteResults);
    }
}
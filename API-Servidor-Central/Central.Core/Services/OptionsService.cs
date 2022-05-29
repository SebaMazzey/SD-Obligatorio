using System.Linq;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Services.Dto;

namespace Central.Core.Services
{
    public class OptionsService : IOptionsService
    {
        private readonly IOptionsRepository _optionsRepository;

        public OptionsService(IOptionsRepository optionsRepository)
        {
            this._optionsRepository = optionsRepository;
        }

        public void UpdateCount(int electionId, VoteResults voteResults)
        {
            // Actualizar el conteo de votos totales del pais para cada Option
            foreach (var results in voteResults)
            {
                this._optionsRepository.Update(new OptionEntity()
                {
                    ElectionId = electionId,
                    Name = results.Key,
                    TotalVotes = results.Value
                });
            }
            this._optionsRepository.SaveChanges();
        }
    }
}
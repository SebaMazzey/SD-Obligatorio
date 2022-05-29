using System.Linq;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Services.Dto;

namespace Central.Core.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionRepository _electionRepository;
        private readonly IDepartmentService _departmentService;
        private readonly IOptionsService _optionsService;

        public ElectionService(IElectionRepository electionRepository, IDepartmentService departmentService, IOptionsService optionsService)
        {
            this._electionRepository = electionRepository;
            this._departmentService = departmentService;
            this._optionsService = optionsService;
        }
        
        public ElectionResults GetElectionResults(int electionId, bool forceUpdate = false)
        {
            // Obtener los resultados de votacion de cada departamento
            var results = new ElectionResults();
            var departmentVotes = this._departmentService.GetAllDepartmentVotes(electionId, forceUpdate);
            results.DepartmentVoteResults = departmentVotes;
            
            // Unificar conteo de cada departamento para obtener resultados totales del pais, y persistirlo
            results.Summary = SummaryVotes(departmentVotes);
            this._optionsService.UpdateCount(electionId, results.Summary);
            return results;
        }

        private static VoteResults SummaryVotes(CountryVoteResults departmentsVotes)
        {
            // Unifica los votos de cada departamento en un unico objeto
            var summary = new VoteResults();
            foreach (var result in departmentsVotes.SelectMany(department => department.Value))
            {
                if (!summary.ContainsKey(result.Key))
                {
                    summary.Add(result.Key, 0);
                }
                summary[result.Key] += result.Value;
            }
            return summary;
        }
    }
}
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

        public ElectionService(IElectionRepository electionRepository, IDepartmentService departmentService)
        {
            this._electionRepository = electionRepository;
            this._departmentService = departmentService;
        }
        
        public ElectionResults GetElectionResults(string electionId)
        {
            var results = new ElectionResults();
            var departmentVotes = this._departmentService.UpdateAllDepartmentVotes().Result;
            results.Summary = SummaryVotes(departmentVotes);
            results.DepartmentVoteResults = departmentVotes;
            return results;
        }

        private static VoteResults SummaryVotes(DepartmentsVoteResults departmentsVotes)
        {
            var summary = new VoteResults();
            foreach (var result in departmentsVotes.SelectMany(department => department.Value))
            {
                summary[result.Key] += result.Value;
            }
            return summary;
        }
    }
}
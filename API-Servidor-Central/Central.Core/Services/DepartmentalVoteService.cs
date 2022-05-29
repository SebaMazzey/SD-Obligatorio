using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Services.Dto;

namespace Central.Core.Services
{
    public class DepartmentalVoteService : IDepartmentalVoteService
    {
        private readonly IDepartmentalVoteRepository _departmentalVoteRepository;

        public DepartmentalVoteService(IDepartmentalVoteRepository departmentalVoteRepository)
        {
            this._departmentalVoteRepository = departmentalVoteRepository;
        }
        
        public async Task UpdateDepartmentVotes(DepartmentVoteResults department)
        {
            // Persistir los nuevos resultados de un departamento
            var taskList = department.VoteResults.Select(result => 
                    _departmentalVoteRepository.AddAsync(new DepartmentalVoteEntity()
                    {
                        OptionName = result.Key,
                        DepartmentName = department.DepartmentName,
                        VotesCount = result.Value
                    }))
                .ToList();
            
            await Task.WhenAll(taskList);
        }

        public CountryVoteResults GetDepartmentVoteResults(int electionId)
        {
            // Obtener los resultados ya persistidos en la base
            var departmentalVoteEntities = this._departmentalVoteRepository.GetResults(electionId);
            return MapDepartmentsResults(departmentalVoteEntities);
        }

        private static CountryVoteResults MapDepartmentsResults(List<DepartmentalVoteEntity> votes)
        {
            // Unificar las entidades de cada resultado departamental en un unico objeto
            var results = new CountryVoteResults();
            foreach (var vote in votes)
            {
                if (!results.ContainsKey(vote.DepartmentName))
                {
                    results.Add(vote.DepartmentName, new VoteResults());
                }
                results[vote.DepartmentName].Add(vote.OptionName, vote.VotesCount);
            }
            return results;
        }
        
        public void DeleteDepartmentalVotes(int electionId)
        {
            this._departmentalVoteRepository.DeleteElectionVotes(electionId);
        }
    }
}
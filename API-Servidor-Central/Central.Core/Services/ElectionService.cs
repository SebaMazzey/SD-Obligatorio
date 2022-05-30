using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Central.Core.Entities;
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

        public void CreateElection(Election election)
        {
            ValidateElection(election);
            var entity = _electionRepository.CreateElection(new ElectionEntity()
            {
                Name = election.Name,
                StartDate = election.StartDate,
                EndDate = election.EndDate
            });

            this._electionRepository.SaveChanges();
            _optionsService.AddElectionOptions(entity.Id, election.Options);
        }

        public IEnumerable<ElectionInfo> GetAllElections()
        {
           return this._electionRepository.GetAllElectionsInfo();
        }

        private void ValidateElection(Election election)
        {
            if (election.StartDate > election.EndDate)
            {
                throw new InvalidDataException("Invalid dates -> Must be consecutives");
            }
            if (this._electionRepository.IsDateTaken(election.StartDate, election.EndDate))
            {
                throw new InvalidDataException("Invalid dates -> Date not available");
            }
        }

        public ElectionResults GetElectionResults(int electionId, bool forceUpdate = false)
        {
            if(!_electionRepository.ElectionIsValid(electionId))
            {
                throw new Exception("El Id no es valido o la elección aún no a terminado");
            }

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
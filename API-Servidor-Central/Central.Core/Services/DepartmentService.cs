using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Interfaces.Services.Clients;
using Central.Core.Services.Dto;

namespace Central.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentalVoteService _departmentalVotesServices;
        private readonly IEnumerable<IDepartmentClient> _departmentClients;

        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentalVoteService departmentalVoteService, IEnumerable<IDepartmentClient> departmentClients)
        {
            this._departmentRepository = departmentRepository;
            this._departmentalVotesServices = departmentalVoteService;
            this._departmentClients = departmentClients;
        }

        public CountryVoteResults GetAllDepartmentVotes(int electionId, bool forceUpdate)
        {
            if (!forceUpdate)
            {
                // Si el resultado ya fue obtenido anteriormente, se obtiene de la base de datos
                var departmentsResults = this._departmentalVotesServices.GetDepartmentVoteResults(electionId);
                if (departmentsResults.Count != 0) { return departmentsResults; }
            }
            else { this._departmentalVotesServices.DeleteDepartmentalVotes(electionId); }

            // Sino se obtienen los nuevos resultados y se persisten
            var newDepartmentResults = this.FetchAllDepartmentsVotes();
            this._departmentRepository.SaveChanges();
            return MapDepartmentsResults(newDepartmentResults);
        }

        private IEnumerable<DepartmentVoteResults> FetchAllDepartmentsVotes()
        {
            // Consultar a cada departamento asincronicamente
            var getVoteResultsTaskList = _departmentClients
                .Select(FetchDepartmentVotes)
                .ToList();

            // Esperar todos los resultados
            return Task.WhenAll(getVoteResultsTaskList).Result;
        }

        private async Task<DepartmentVoteResults> FetchDepartmentVotes(IDepartmentClient client)
        {
            // Consultarle a un servidor departamental por sus resultados y persistirlos
            var voteResults = client.GetVoteResults().Result;
            await this._departmentalVotesServices.UpdateDepartmentVotes(voteResults);
            return voteResults;
        }

        private static CountryVoteResults MapDepartmentsResults(IEnumerable<DepartmentVoteResults> votes)
        {
            // Unificar los votos de cada departamento en un unico objeto
            var results = new CountryVoteResults();
            foreach (var vote in votes)
            {
                results.Add(vote.DepartmentName, vote.VoteResults);
            }
            return results;
        }
    }
}
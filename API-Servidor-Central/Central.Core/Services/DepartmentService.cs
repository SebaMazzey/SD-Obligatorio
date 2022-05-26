using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Interfaces.Services;
using Central.Core.Services.Dto;

namespace Central.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentalVoteRepository _departmentalVoteRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentalVoteRepository departmentalVoteRepository)
        {
            this._departmentRepository = departmentRepository;
            this._departmentalVoteRepository = departmentalVoteRepository;
        }

        public async Task<DepartmentsVoteResults> UpdateAllDepartmentVotes()
        {
            var departmentsResults = await this.GetAllDepartmentsVotes();
            return MapDepartmentsResults(departmentsResults);
        }

        private async Task<DepartmentVoteResults[]> GetAllDepartmentsVotes()
        {
            var departments = await this._departmentRepository.ListAllAsync();
            
            var getVoteResultsTaskList = departments
                .Select(e => GetDepartmentVotes(e.Name))
                .ToList();
            
            return await Task.WhenAll(getVoteResultsTaskList);
        }

        private async Task<DepartmentVoteResults> GetDepartmentVotes(string departmentName)
        {
            var department = await Task.Run(() => new DepartmentVoteResults()); // TODO
            await UpdateDepartmentVotes(department);
            return department;
        }

        private async Task UpdateDepartmentVotes(DepartmentVoteResults department)
        {
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

        private static DepartmentsVoteResults MapDepartmentsResults(DepartmentVoteResults[] votes)
        {
            var results = new DepartmentsVoteResults();
            foreach (var vote in votes)
            {
                results.Add(vote.DepartmentName, vote.VoteResults);
            }
            return results;
        }
    }
}
using Departments_Core.Interfaces.Repositories;
using Departments_Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departments_Core.Entities;
using Departments_Core.Services.Dto;

namespace Departments_Core.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IPersonService _personService;

        public VoteService(IVoteRepository voteRepository, IPersonService personService)
        {
            this._voteRepository = voteRepository;
            this._personService = personService;
        }

        public void AddVote(Vote vote)
        {
            SaveVote(vote);
            _personService.MarkAsVoted(vote.Ci);            
        }

        private void SaveVote(Vote vote)
        {
            _voteRepository.AddAsync(new VoteEntity
            {
                Circuit_Number = vote.CircuitNumber,
                Option_Name = vote.Option
            });
        }
    }
}

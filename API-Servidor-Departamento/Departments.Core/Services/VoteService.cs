﻿using Departments_Core.Interfaces.Repositories;
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
        private readonly IUserService _userService;

        public VoteService(IVoteRepository voteRepository, IUserService userService)
        {
            this._voteRepository = voteRepository;
            this._userService = userService;
        }

        public void AddVote(Vote vote)
        {
            SaveVote(vote);
            _userService.MarkAsVoted(vote.Ci);            
        }

        public Dictionary<string, int> GetResults()
        {
            return _voteRepository.CountVotingResults();
        }

        private void SaveVote(Vote vote)
        {
            _voteRepository.AddAsync(new VoteEntity
            {
                CircuitNumber = vote.CircuitNumber,
                OptionName = vote.Option
            });
        }
    }
}

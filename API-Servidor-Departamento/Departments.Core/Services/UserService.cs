using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using Departments_Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task<bool> VerifyUser(string ci)
        {
            var hashedCi = CryptoService.ComputeSha256Hash(ci);
            var isAbleToVote = _userRepository.CountNotVotedUsersWithCI(hashedCi) != 0;
            return Task.FromResult(isAbleToVote);
        }

        public void MarkAsVoted(string hashedCi)
        {
            this._userRepository.Update(new UserEntity()
            {
                Ci = hashedCi,
                AlreadyVoted = true
            });
        }

        public int CountRemainingVotes()
        {
            return this._userRepository.CountRemainingVotes();
        }
    }
}

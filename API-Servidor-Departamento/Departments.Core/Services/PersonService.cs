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
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        public Task<bool> VerifyUser(string ci)
        {
            var isAbleToVote = _personRepository.CountNotVotedUsersWithCI(ci) != 0;
            return Task.FromResult(isAbleToVote);
        }

        public void MarkAsVoted(string ci)
        {
            this._personRepository.Update(new PersonEntity()
            {
                Ci = ci,
                Already_Voted = true
            });
        }
    }
}

using Departments.DAL.EFCore.Core;
using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Departments.DAL.EFCore.Repositories
{
    public class UserRepository: EfRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DepartmentContext context): base(context) { }

        public int CountNotVotedUsersWithCI(string ci)
        {
            return this._dbContext.Users.Count(user => user.Ci == ci && !user.AlreadyVoted);
        }

        public int CountRemainingVotes()
        {
            return this._dbContext.Users.Count(user => !user.AlreadyVoted);
        }
    }
}

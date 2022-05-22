using Departments_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<bool> VerifyUser(string ci);
        public void MarkAsVoted(string ci);
        public int CountRemainingVotes();
    }
}

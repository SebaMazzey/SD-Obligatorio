using System;
using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using Departments.DAL.EFCore.Core;
using System.Linq;

namespace Departments.DAL.EFCore.Repositories
{
    public class TokenRepository : EfRepository<TokenEntity>, ITokenRepository
    {
        public TokenRepository(DepartmentContext context) : base(context)
        {
        }
        
        public int TokenIsValid(string token, string ci)
        {
            return this._dbContext.Tokens.Count(t => t.Token.Equals(token) && t.Ci.Equals(ci) && t.ExpirationDate > DateTime.Now);
        }
    }
}
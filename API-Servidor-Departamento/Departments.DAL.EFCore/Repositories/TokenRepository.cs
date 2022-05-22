using System;
using Departments_Core.Entities;
using Departments_Core.Interfaces.Repositories;
using Departments.DAL.EFCore.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.Types;
using MySql.EntityFrameworkCore.Extensions;

namespace Departments.DAL.EFCore.Repositories
{
    public class TokenRepository : EfRepository<TokenEntity>, ITokenRepository
    {
        public TokenRepository(DepartmentContext context) : base(context) { }
        
        public TokenEntity FindValidToken(string token, string ci)
        {
            return this._dbContext.Tokens.Where(t =>
                t.Token.Equals(token) && t.Ci.Equals(ci))
                .Select(t => t)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public void DeleteTokensWithCi(string ci)
        {
            this._dbContext.Tokens.RemoveRange(this._dbContext.Tokens.Where(e => e.Ci.Equals(ci)));
        }
    }
}
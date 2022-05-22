using Departments_Core.Entities;

namespace Departments_Core.Interfaces.Repositories
{
    public interface ITokenRepository : IRepository<TokenEntity>
    {
        TokenEntity FindValidToken(string token, string ci);
        void DeleteTokensWithCi(string ci);
        void DeleteToken(string token);
    }
}
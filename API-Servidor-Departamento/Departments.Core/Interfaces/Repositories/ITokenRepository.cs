using Departments_Core.Entities;

namespace Departments_Core.Interfaces.Repositories
{
    public interface ITokenRepository : IRepository<TokenEntity>
    {
        int TokenIsValid(string token, string ci);
    }
}
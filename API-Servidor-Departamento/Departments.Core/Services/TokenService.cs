using System.Security.Authentication;
using Departments_Core.Interfaces.Repositories;
using Departments_Core.Interfaces.Services;

namespace Departments_Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            this._tokenRepository = tokenRepository;
        }
        
        public void VerifyToken(string token, string ci)
        {
            if (_tokenRepository.TokenIsValid(token, ci) != 1)
            {
                throw new AuthenticationException("Invalid or expired token");
            }
        }
    }
}
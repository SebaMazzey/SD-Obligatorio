using System;
using System.Security.Authentication;
using Departments_Core.Entities;
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
            var tokenEntity = this._tokenRepository.FindValidToken(token, ci);
            if (tokenEntity == null)
            {
                throw new AuthenticationException("Invalid token");
            } 
            if (tokenEntity.ExpirationDate <= DateTime.Now)
            {
                DeleteToken(token);
                throw new AuthenticationException("Expired token");
            }
        }

        public void DeleteToken(string token)
        {
            this._tokenRepository.DeleteToken(token);
        }

        public string CreateToken(string ci)
        {
            this._tokenRepository.DeleteTokensWithCi(ci);
            var token = Guid.NewGuid().ToString();
            _tokenRepository.AddAsync(new TokenEntity()
            {
                Ci = ci,
                Token = token,
                ExpirationDate = DateTime.Now.AddMinutes(5)
            });
            return token;
        }

        public void SaveChanges()
        {
            this._tokenRepository.SaveChanges();
        }
    }
}
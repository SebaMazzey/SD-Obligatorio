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
                this._tokenRepository.Delete(tokenEntity);
                throw new AuthenticationException("Expired token");
            }
        }

        public void DeleteToken(string token)
        {
            this._tokenRepository.Delete(new TokenEntity() { Token = token });
        }

        public string CreateToken(string ci)
        {
            var hashedCi = CryptoService.ComputeSha256Hash(ci);
            this._tokenRepository.DeleteTokensWithCi(hashedCi);
            var token = Guid.NewGuid().ToString();
            SaveToken(token, hashedCi);
            this._tokenRepository.SaveChanges();
            return token;
        }

        private void SaveToken(string token, string ci)
        {
            _tokenRepository.AddAsync(new TokenEntity()
            {
                Ci = ci,
                Token = token,
                ExpirationDate = DateTime.Now.AddMinutes(5)
            });
        }
    }
}
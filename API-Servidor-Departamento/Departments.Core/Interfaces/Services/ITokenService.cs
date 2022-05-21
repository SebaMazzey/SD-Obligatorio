namespace Departments_Core.Interfaces.Services
{
    public interface ITokenService
    {
        void VerifyToken(string token, string ci);
    }
}
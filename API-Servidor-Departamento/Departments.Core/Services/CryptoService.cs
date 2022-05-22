using System.Security.Cryptography;
using System.Text;

namespace Departments_Core.Services
{
    public class CryptoService
    {
        public static string ComputeSha256Hash(string raw)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(raw));
                var sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }  
                return sb.ToString();  
            } 
        }
    }
}
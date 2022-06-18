using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitosApp.Services
{
    public class UserService
    {
        public string SessionToken { get; private set; }

        public UserService()
        {
        }

        /// <summary>
        /// Intenta loguear al usuario en la api departamental para proceder con la votación.
        /// </summary>
        /// <param name="userCi">CI del usuario</param>
        /// <return> Devuelve true si el usuario se loguea con exito.</returns>
        public bool LogInUser(string userCi)
        {
            var resultToken = HttpService.CallDepartmentApiAsync("User/Verify?ci=" + userCi, HttpService.RequestType.Get);
            if (resultToken != "")
            {
                this.SessionToken = resultToken;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Limpia el token en caso de que el procesos de votación finalice con exito
        /// </summary>
        public void ClearToken()
        {
            this.SessionToken = "";
        }
    }
}

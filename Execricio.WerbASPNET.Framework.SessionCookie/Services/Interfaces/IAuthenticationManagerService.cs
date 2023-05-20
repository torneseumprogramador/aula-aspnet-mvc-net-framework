using Execricio.WerbASPNET.Framework.SessionCookie.Requests;
using Execricio.WerbASPNET.Framework.SessionCookie.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Services.Interfaces
{
    public interface IAuthenticationManagerService
    {
        /// <summary>
        /// Realiza o login do usuário com base nas informações fornecidas.
        /// </summary>
        /// <param name="request">As informações de login do usuário.</param>
        /// <returns>Uma resposta indicando o resultado da operação de login.</returns>
        LoginResponse Login(LoginRequest request);

        /// <summary>
        /// Realiza o logout do usuário.
        /// </summary>
        /// <param name="request">As informações de logout do usuário.</param>
        /// <returns>Uma resposta indicando o resultado da operação de logout.</returns>
        LogoutResponse Logout(LogoutRequest request);
    }
}

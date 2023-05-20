using Execricio.WerbASPNET.Framework.SessionCookie.Configurations.Enum;
using Execricio.WerbASPNET.Framework.SessionCookie.Requests;
using Execricio.WerbASPNET.Framework.SessionCookie.Responses;
using Execricio.WerbASPNET.Framework.SessionCookie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Services
{
    public class AuthenticationManagerService : IAuthenticationManagerService
    {
        private AuthenticationType _authenticationType;

        public AuthenticationManagerService(AuthenticationType authenticationType)
        {
            _authenticationType = authenticationType;
        }

        public LoginResponse Login(LoginRequest request)
        {
            return new LoginResponse();
        }

        public LogoutResponse Logout(LogoutRequest request)
        {
            return new LogoutResponse();
        }

        /// <summary>
        /// Verifica se o usuário é válido com base no nome de usuário e senha fornecidos.
        /// </summary>
        /// <param name="username">O nome de usuário.</param>
        /// <param name="password">A senha do usuário.</param>
        /// <returns>True se o usuário for válido, False caso contrário.</returns>
        private bool IsValidUser(string username, string password)
        {
            return (username == "admin" && password == "admin123");
        }

        private void SetAuthenticationInfo(string username)
        {
            if (_authenticationType == AuthenticationType.Session)
            {
                HttpContext.Current.Session["Username"] = username;
            }
            else if (_authenticationType == AuthenticationType.Cookie)
            {
                // Lógica para armazenar as informações de autenticação em um cookie
                // Exemplo:
                var cookie = new HttpCookie("Username", username);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                // Outra lógica de armazenamento de acordo com o AuthenticationType desejado
            }
        }

        private void ClearAuthenticationInfo()
        {
            if (_authenticationType == AuthenticationType.Session)
            {
                HttpContext.Current.Session.Remove("Username");
            }
            else if (_authenticationType == AuthenticationType.Cookie)
            {
                // Lógica para remover as informações de autenticação do cookie
                // Exemplo:
                var cookie = HttpContext.Current.Request.Cookies["Username"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                // Outra lógica de remoção de acordo com o AuthenticationType desejado
            }
        }
    }
}
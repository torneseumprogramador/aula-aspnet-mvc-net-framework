using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
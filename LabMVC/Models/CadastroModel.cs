using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMVC.Models
{
    public class CadastroModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
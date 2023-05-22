using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMVC.Models.Response
{
    public class UsuarioResponse
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
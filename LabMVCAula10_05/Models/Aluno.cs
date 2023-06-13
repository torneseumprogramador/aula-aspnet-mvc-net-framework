using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMVCAula10_05.Models
{
    public partial class Aluno
    {


            public string Nome { get; set; }
            public int Matricula { get; set; }
            public string Notas { get; set; }
            public int Media { get; set; }
            public Situacao Situacao { get; set; }
        
    }

    public enum Situacao
    {
        Reprovado,
        Recuperacao,
        Aprovado
    }

}

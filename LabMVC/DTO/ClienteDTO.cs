
using LabWebForms.Models;

namespace LabMVC.DTO
{
    public class ClienteDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
}
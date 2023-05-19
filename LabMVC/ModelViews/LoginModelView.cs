using System.ComponentModel.DataAnnotations;

namespace LabMVC.ModelViews
{
    public class LoginModelView
    {
        [Required(ErrorMessage = "Campo de usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo de senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
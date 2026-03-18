using System.ComponentModel.DataAnnotations;

namespace cp4_Projeto.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário é obrigatório")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}

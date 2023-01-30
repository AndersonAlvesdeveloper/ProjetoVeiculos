using System.ComponentModel.DataAnnotations;

namespace Veiculos.Presentation.Models
{
    public class ContaLoginModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a sua senha.")]
        public string Senha { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Veiculos.Presentation.Models
{
    public class ContaPasswordModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o seu email de acesso.")]
        public string Email { get; set; }

    }
}

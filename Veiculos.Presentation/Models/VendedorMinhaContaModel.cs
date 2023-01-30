using System.ComponentModel.DataAnnotations;

namespace Veiculos.Presentation.Models
{
    public class VendedorMinhaContaModel
    {

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a sua senha.")]
        public string NovaSenha { get; set; }

        [Compare("NovaSenha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme a sua senha.")]
        public string NovaSenhaConfirmacao { get; set; }
        
    }
}

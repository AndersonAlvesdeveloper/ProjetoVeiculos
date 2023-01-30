using System.ComponentModel.DataAnnotations;

namespace Veiculos.Presentation.Models
{
    public class VeiculoEdicaoModel
    {
        [Required] //campo oculto
        public Guid IdVeiculo { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Marca do Veiculo.")]
        public string Marca { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Cor do Veiculo.")]
        public string Cor { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe Ano do Veiculo.")]
        public string Ano { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe Modelo do Veiculo.")]
        public string Modelo { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Placa do Veiculo.")]
        public string Placa { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe Chassi do Veiculo.")]
        public string Chassi { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o Valor da Entrada do Veiculo.")]
        public string ValorEntrada { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o Valor do Final do Veiculo.")]
        public string ValorFinal { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o Valor da Venda do Veiculo.")]
        public string ValorDeVenda { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe as melhorias feitas Veiculo.")]
        public string Melhorias { get; set; }
    }
}

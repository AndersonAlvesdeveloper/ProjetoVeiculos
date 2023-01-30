using System.ComponentModel.DataAnnotations;

namespace Veiculos.Presentation.Models
{                   /// <summary>
                    /// Modelo de dados para a página de consulta de VEICULOS
                    /// </summary>

    public class VeiculoConsultaModel
    {
        public  Guid IdVeiculo { get; set; }

        public string Marca { get; set; }

       
        public string Cor { get; set; }

       
        public string Ano { get; set; }

        
        public string Modelo { get; set; }

      
        public string Placa { get; set; }

       
        public string Chassi { get; set; }

       
        public string ValorEntrada { get; set; }

       
        public string ValorFinal { get; set; }

        
        public string ValorDeVenda { get; set; }

        
        public string Melhorias { get; set; }
    }
}

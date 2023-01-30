using Microsoft.Build.Framework;
using Microsoft.SqlServer.Server;


namespace Veiculos.Presentation.Models
{
    public class VeiculoRelatorioModel
    {
        [Required]

        public string Formato { get; set; }
    }
}

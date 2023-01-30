using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Data.Entities
{
    public class Veiculo
    {
        #region Propriedades

        public Guid IdVeiculo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string ValorEntrada { get; set; }
        public string ValorFinal{ get; set; }
        public string ValorDeVenda { get; set; }
        public string Melhorias { get; set; }
        public Guid IdVendedor { get; set; }

        #endregion

        #region Relacionamentos

        public Vendedor Vendedor { get; set; }

        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Data.Entities
{
    public class Vendedor
    {
        #region Propriedades

        public Guid IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        #endregion
        #region Relacionamentos

        public List<Veiculo>Veiculos { get; set; }

        #endregion




    }
}

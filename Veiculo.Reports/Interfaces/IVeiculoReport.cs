using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Data.Entities;

namespace Veiculos.Reports.Interfaces
{
    public interface IVeiculoReport
    {
        byte[] CreateReport(List<Veiculo> veiculos,Vendedor vendedor);
    }
}

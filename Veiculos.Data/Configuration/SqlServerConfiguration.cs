using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Data.Configuration
{
    public class SqlServerConfiguration
    {
        /// <summary>
        /// Método para retornar a connectionstring do banco de dados
        /// </summary>
        public static string GetConnectionString => @"Data Source=(localdb)\MSSQLLocalDB;
        Initial Catalog=BDVeiculos;Integrated Security=True;Connect Timeout=30;
        Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
        MultiSubnetFailover=False";




    }
}

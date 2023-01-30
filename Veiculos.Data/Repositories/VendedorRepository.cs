using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Data.Configuration;
using Veiculos.Data.Entities;

namespace Veiculos.Data.Repositories
{
    public class VendedorRepository
    { /// <summary>
      /// Método para inserir um Vendedor no banco de dados
      /// </summary>
        public void Create(Vendedor vendedor)
        {
            var query = @"
                INSERT INTO VENDEDOR(
                    IDVENDEDOR,
                    NOME,
                    EMAIL,
                    SENHA,
                    DATACRIACAO)
                VALUES(
                    @IdVendedor,
                    @Nome,
                    @Email,
                    CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2),
                    @DataCriacao
                )
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, vendedor);
            }
        }

        /// <summary>
        /// Método para atualizar somente a senha do vendedor
        /// </summary>
        public void Update(Guid idVendedor, string novaSenha)
        {
            var query = @"
                UPDATE VENDEDOR 
                SET SENHA = CONVERT(VARCHAR(32), HASHBYTES('MD5', @novaSenha), 2)
                WHERE IDVENDEDOR = @idVendedor
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, new { idVendedor, novaSenha });
            }
        }


        /// <summary>
        /// Método para consultar 1 Vendedor baseado no email
        /// </summary>
        public Vendedor GetByEmail(string email)
        {
            var query = @"
                SELECT * FROM VENDEDOR
                WHERE EMAIL = @email
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection
                    .Query<Vendedor>(query, new { email })
                    .FirstOrDefault();
            }
        }


        /// <summary>
        /// Método para consultar 1 Vendedor baseado no email e senha
        /// </summary>
        public Vendedor GetByEmailAndSenha(string email, string senha)
        {
            var query = @"
                SELECT * FROM VENDEDOR
                WHERE EMAIL = @email AND SENHA = CONVERT(VARCHAR(32), 
                HASHBYTES('MD5', @senha), 2)
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection
                    .Query<Vendedor>(query, new { email, senha })
                    .FirstOrDefault();
            }
        }
    }
}




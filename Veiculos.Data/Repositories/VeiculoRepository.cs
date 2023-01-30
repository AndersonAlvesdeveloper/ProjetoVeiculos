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
    public class VeiculoRepository
    {
        /// <summary>
        /// Método para inserir um Vendedor no banco de dados
        /// </summary>
        public void Create(Veiculo veiculo)
        {
            var query = @"
                INSERT INTO VEICULO  (
                    IDVEICULO,
                    MARCA,
                    COR,
                    ANO,
                    MODELO,
                    PLACA,
                    CHASSI,
                    VALORENTRADA,
                    VALORFINAL,
                    VALORDEVENDA,
                    MELHORIAS,
                    IDVENDEDOR)            
                VALUES(
                    @IdVeiculo,
                    @Marca,
                    @Cor,
                    @Ano,
                    @Modelo,
                    @Placa,
                    @Chassi,
                    @ValorEntrada,
                    @ValorFinal,
                    @ValorDeVenda,
                    @Melhorias,
                    @IdVendedor
                   
                   
                )
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, veiculo);
            }
        }

        public void Update(Veiculo veiculo)
        {
            var query = @"
                UPDATE VEICULO
                SET
                    MARCA = @Marca,
                    COR = @Cor,
                    ANO = @Ano,
                    MODELO = @Modelo,
                    PLACA =  @Placa,
                    CHASSI =  @Chassi,
                    VALORENTRADA =  @ValorEntrada,
                    VALORFINAL = @Melhorias,
                    VALORDEVENDA =  @Melhorias,
                    MELHORIAS = @Melhorias
                    WHERE IDVEICULO = @IdVeiculo
                    
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, veiculo);
            }
        }

        public void Delete(Veiculo veiculo)
        {
            var query = @"
                DELETE FROM VEICULO
                WHERE IDVEICULO = @IdVeiculo   
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, veiculo);
            }
        }

        public List<Veiculo> GetAllByVendedor(Guid idVendedor)
        {
            var query = @"
                SELECT * FROM VEICULO
                WHERE IDVENDEDOR = @idVendedor
                ORDER BY MARCA
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection.Query<Veiculo>(query, new { idVendedor }).ToList();
            }
        }

        public Veiculo? GetById(Guid idVeiculo)
        {
            var query = @"
                SELECT * FROM VEICULO
                WHERE IDVEICULO = @idVeiculo
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection.Query<Veiculo>(query, new { idVeiculo }).FirstOrDefault();
            }



        }

    }
}

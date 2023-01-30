using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Data.Entities;
using Veiculos.Reports.Interfaces;

namespace Veiculos.Reports.Services.NovaPasta
{
    public class VeiculoReportServiceExcel : IVeiculoReport
    {
        public byte[] CreateReport(List<Veiculo> veiculos, Vendedor vendedor)
        {
            //define o tipo de licença para não comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //criando a planilha
            using (var excelPackage = new ExcelPackage())
            {
                //definindo o nome da planilha dentro do arquivo
                var sheet = excelPackage.Workbook.Worksheets.Add("Veiculos");

                sheet.Cells["A1"].Value = "Relatório de Veiculos";

                sheet.Cells["A3"].Value = "Nome do Vendedor";
                sheet.Cells["B3"].Value = vendedor.Nome;

                sheet.Cells["A4"].Value = "Email do Vendedor";
                sheet.Cells["B4"].Value = vendedor.Email;

                sheet.Cells["A5"].Value = "Data/Hora de geração";
                sheet.Cells["B5"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                sheet.Cells["A7"].Value = "Marca";
                sheet.Cells["B7"].Value = "Cor ";
                sheet.Cells["C7"].Value = "Ano ";
                sheet.Cells["D7"].Value = "Modelo ";
                sheet.Cells["E7"].Value = "Placa ";
                sheet.Cells["F7"].Value = "Chassi ";
                sheet.Cells["G7"].Value = "ValorEntrada";
                sheet.Cells["H7"].Value = "ValorFinal ";
                sheet.Cells["I7"].Value = "ValorDeVenda ";
                sheet.Cells["J7"].Value = "Melhorias ";
               


                var linha = 8;
                foreach (var item in veiculos)
                {
                    sheet.Cells[$"A{linha}"].Value = item.Marca;
                    sheet.Cells[$"B{linha}"].Value = item.Cor ;
                    sheet.Cells[$"C{linha}"].Value = item.Ano ;
                    sheet.Cells[$"D{linha}"].Value = item.Modelo ;
                    sheet.Cells[$"E{linha}"].Value = item.Placa ;
                    sheet.Cells[$"F{linha}"].Value = item.Chassi ;
                    sheet.Cells[$"G{linha}"].Value = item.ValorEntrada;
                    sheet.Cells[$"H{linha}"].Value = item.ValorFinal ;
                    sheet.Cells[$"I{linha}"].Value = item.ValorDeVenda ;
                    sheet.Cells[$"J{linha}"].Value = item.Melhorias ;



                    linha++;
                }

                sheet.Cells["A:E"].AutoFitColumns();

                //retornando o arquivo
                return excelPackage.GetAsByteArray();
            }
        }
    }
}

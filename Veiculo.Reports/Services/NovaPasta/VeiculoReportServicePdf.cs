using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Data.Entities;
using Veiculos.Reports.Interfaces;
using iText.Layout;
using Document = iText.Layout.Document;

namespace Veiculos.Reports.Services.NovaPasta
{
    public class VeiculoReportServicePdf : IVeiculoReport
    {
        public byte[] CreateReport(List<Veiculo> veiculos, Vendedor vendedor)
        {
            var memoryStream = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(memoryStream));

            //montando o documento PDF
            using (var document = new Document(pdf))
            {
                document.Add(new Paragraph("Relatório de Contatos\n"));

                document.Add(new Paragraph($"Nome do Vendedor: {vendedor.Nome}"));
                document.Add(new Paragraph($"Email do usuário: {vendedor.Email}"));
                document.Add(new Paragraph($"Data/Hora de geração: { DateTime.Now.ToString("dd/MM/yyyy") }"));

                var table = new Table(10);
                table.SetWidth(UnitValue.CreatePercentValue(100));

                table.AddHeaderCell("Marca ");
                table.AddHeaderCell("Cor ");
                table.AddHeaderCell("Ano ");
                table.AddHeaderCell("Modelo ");
                table.AddHeaderCell("Placa ");
                table.AddHeaderCell("Chassi ");
                table.AddHeaderCell("ValorEntrada ");
                table.AddHeaderCell("ValorFinal ");
                table.AddHeaderCell("ValorDeVenda ");
                table.AddHeaderCell("Melhorias ");


                foreach (var item in veiculos)
                {
                    table.AddCell(item.Marca);
                    table.AddCell(item.Cor);
                    table.AddCell(item.Ano);
                    table.AddCell(item.Modelo);
                    table.AddCell(item.Placa);
                    table.AddCell(item.Chassi);
                    table.AddCell(item.ValorEntrada);
                    table.AddCell(item.ValorFinal);
                    table.AddCell(item.ValorDeVenda);
                    table.AddCell(item.Melhorias);


                }

                document.Add(table);
            }

            return memoryStream.ToArray();
        }
    }
}

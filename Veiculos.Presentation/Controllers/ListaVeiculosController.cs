using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Veiculos.Data.Entities;
using Veiculos.Data.Repositories;
using Veiculos.Presentation.Models;
using Veiculos.Reports.Interfaces;
using Veiculos.Reports.Services.NovaPasta;

namespace Veiculos.Presentation.Controllers
{
    [Authorize]    //[Authorize (Rles = ADMIN)]
    public class ListaVeiculosController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost] //recebe o submit do formulário
        public IActionResult Cadastro(VeiculoCadastroModel model)
        {
            if (ModelState . IsValid)
            {
                try
                {
                    //capturar o Vendedor autenticado no sistema
                    var auth = ObterVendedorAutenticado();


                    var veiculo = new Veiculo
                    {
                         IdVeiculo = Guid.NewGuid(),
                         Marca = model.Marca,
                         Cor = model.Cor,
                         Ano = model.Ano,
                         Modelo= model.Modelo,
                         Placa= model.Placa,
                         Chassi = model.Chassi,
                         ValorEntrada= model.ValorEntrada,  
                         ValorFinal= model.ValorFinal,  
                         ValorDeVenda= model.ValorDeVenda,
                         Melhorias= model.Melhorias,
                         IdVendedor= auth. IdVendedor
                         


                    };


                    //cadastrando no banco de dados
                    var veiculoRepository = new VeiculoRepository();
                    veiculoRepository.Create(veiculo);

                    TempData["MensagemSucesso"]= $"Contato {veiculo.Marca}, cadastrado com sucesso.";

                    ModelState.Clear();
                }
                catch (Exception e)
                {

                    TempData["MensagemErro"]= $"Falha ao cadastrar o Veiculo: {e.Message}";

                }

            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário de cadastro, por favor verifique.";

            }

            return View();
        }




        public IActionResult Consulta()
        {
            var lista = new List<VeiculoConsultaModel>();

            try
            {
                //obtendo o vendedor autenticado
                var auth = ObterVendedorAutenticado();

                //consultar todos os contatos no banco de dados
                //pertencentes ao usuário que está autenticado
                var veiculoRepository = new VeiculoRepository();
                foreach (var item in veiculoRepository.GetAllByVendedor(auth.IdVendedor))
                {
                    var model = new VeiculoConsultaModel
                    {
                        IdVeiculo = item.IdVeiculo,
                        Marca = item.Marca,
                        Cor = item.Cor,
                        Ano = item.Ano,
                        Modelo = item.Modelo,
                        Placa = item.Placa,
                        Chassi = item.Chassi,
                        ValorEntrada = item.ValorEntrada,
                        ValorFinal = item.ValorFinal ,
                        ValorDeVenda  = item.ValorDeVenda,
                        Melhorias = item.Melhorias
                       
                       
                    };

                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"]= $"Falha ao consultar veiculo: {e.Message}";
            }

            return View(lista);
        }





        public IActionResult Edicao(Guid id)
        {
            try
            {
                //consultar os dados do contato atraves do ID
                var veiculoRepository = new VeiculoRepository();
                var veiculo = veiculoRepository.GetById(id);


                //verificar se o contato foi encontrado e
                //verificar se o contato pertence ao usuário autenticado

                if (veiculo != null && veiculo.IdVendedor == ObterVendedorAutenticado().IdVendedor)
                {
                    //criando uma instancia da classe ContatosEdicaoModel
                    var model = new VeiculoEdicaoModel
                    {
                        IdVeiculo = veiculo.IdVeiculo,
                        Marca = veiculo.Marca,
                        Cor = veiculo.Cor,
                        Ano = veiculo.Ano,
                        Modelo = veiculo.Modelo,
                        Placa = veiculo.Placa,
                        Chassi = veiculo.Chassi,
                        ValorEntrada = veiculo.ValorEntrada,
                        ValorFinal = veiculo.ValorFinal,
                        ValorDeVenda = veiculo.ValorDeVenda,
                        Melhorias = veiculo.Melhorias

                        
                    };

                    //enviando o objeto 'model' para a página
                    return View(model);
                }
                else
                {
                    TempData["MensagemAlerta"] = $"Contato não encontrado.";
                    return RedirectToAction("Consulta");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"]= $"Falha ao obter contato: {e.Message}";
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edicao(VeiculoEdicaoModel model)
        {
            //verificar se todos os campos passaram nas regras de validação

            if (ModelState.IsValid)
            {
                try
                {
                    var contato = new Veiculo
                    {
                        IdVeiculo = model.IdVeiculo,
                        Marca = model.Marca,
                        Cor = model.Cor,
                        Ano = model.Ano,
                        Modelo = model.Modelo,
                        Placa = model.Placa,
                        Chassi = model.Chassi,
                        ValorEntrada = model.ValorEntrada,
                        ValorFinal = model.ValorFinal,
                        ValorDeVenda = model.ValorDeVenda,
                        Melhorias = model.Melhorias

                        
                    };

                    //atualizando no banco de dados
                    var veiculoRepository = new VeiculoRepository();
                    veiculoRepository.Update(contato);

                    TempData["MensagemSucesso"] = $"Contato {contato.Modelo}, atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"]= $"Falha ao editar contato: {e.Message}";
                }
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário de edição, por favor verifique.";
            }

            return View();
        }






        public IActionResult Exclusao(Guid id)
        {
            try
            {
                //consultar o contato atraves do ID
                var veiculoRepository = new VeiculoRepository();
                var veiculo = veiculoRepository.GetById(id);

                //verificar se o contato foi encontrado e
                //verificar se o contato pertence ao usuário autenticado
                if (veiculo != null && veiculo.IdVeiculo == ObterVendedorAutenticado().IdVendedor)
                {
                    //excluindo o contato
                    veiculoRepository.Delete(veiculo);
                    TempData["MensagemSucesso"] = $"Contato {veiculo.Marca}, excluído com sucesso.";
                }
                else
                {
                    TempData["MensagemAlerta"] = "Contato não encontrado.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"]= $"Falha ao excluir o contato: {e.Message}";
            }

            return RedirectToAction("Consulta");
        }


        //método auxiliar para retornar o usuário autenticado
        private AutenticacaoModel ObterVendedorAutenticado()
        {
            //ler os dados contidos no cookie (JSON)
            var json = User.Identity.Name;
            //deserializar o JSON e retornar o objeto
            return JsonConvert.DeserializeObject<AutenticacaoModel>(json);
        }


        public IActionResult Relatorio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Relatorio(VeiculoRelatorioModel model)
        {
            //verificar se todos os campos passaram nas validações
            if (ModelState.IsValid)
            {
                try
                {
                    string tipoArquivo = null; //MIME TYPE
                    string nomeArquivo = $"veiculos_{DateTime.Now.ToString("ddMMyyyyHHmmss")}";
                    IVeiculoReport veiculoReport = null;

                    switch (model.Formato)
                    {
                        case "pdf":
                            tipoArquivo = "application/pdf";
                            nomeArquivo += ".pdf";
                            veiculoReport= new VeiculoReportServicePdf(); //Polimorfismo
                            break;

                        case "excel":
                            tipoArquivo = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            nomeArquivo += ".xlsx";
                            veiculoReport= new VeiculoReportServiceExcel(); //Polimorfismo
                            break;
                    }



                    //capturando o vendedor autenticado
                    var auth = ObterVendedorAutenticado();
                    var vendedor = new Vendedor
                    {
                        IdVendedor = auth.IdVendedor,
                        Nome = auth.Nome,
                        Email = auth.Email
                    };

                    //consultando os contatos no banco de dados
                    var veiculoRepository = new VeiculoRepository();
                    var veiculo = veiculoRepository.GetAllByVendedor(vendedor.IdVendedor);

                    //gerando o arquivo
                    var relatorio = veiculoReport.CreateReport(veiculo, vendedor);

                    //download
                    return File(relatorio, tipoArquivo, nomeArquivo);
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"]= $"Falha ao gerar relatório: {e.Message}";
                }
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário de relatorios, por favor verifique.";
            }

            return View();
        }



    }
}

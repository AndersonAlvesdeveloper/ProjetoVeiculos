using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Veiculos.Data.Entities;
using Veiculos.Data.Repositories;
using Veiculos.Presentation.Models;
using Veiculos.Messages.Services;
using Bogus;

namespace Veiculos.Presentation.Controllers
{
    public class ContaController : Controller
    {        //Rotas a baixos
        public IActionResult Login()
        {
            return View();     //Acesso de pagina
        }
        [HttpPost] //Recebe o SUBMIT do formulário
        public IActionResult Login(ContaLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vendedorRepository = new VendedorRepository();

                    //consultar o Vendedor no banco de dados 
                    //através do email e da senha]
                    var vendedor = vendedorRepository.GetByEmailAndSenha(model.Email, model.Senha);

                    //verificar se o Vendedor não foi encontrado
                    if (vendedor == null)
                    {
                        TempData["Mensagem"] = "Acesso negado.";
                    }
                    else
                    {
                        //realizando a autenticação do Vendedor
                        var autenticacaoModel = new AutenticacaoModel
                        {
                            IdVendedor = vendedor.IdVendedor,
                            Nome = vendedor.Nome,
                            Email = vendedor.Email,
                            DataHoraAcesso = DateTime.Now
                        };

                        //serializando os dados da model em JSON
                        var json = JsonConvert.SerializeObject(autenticacaoModel);

                        //gerar o conteudo para gravação 
                        //no cookie de autenticação
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, json) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        //gravando o cookie de autenticação
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        //redirecionar para a página: /Home/Index
                        return RedirectToAction("Index", "Home");




                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Erro: {e.Message}";
                }
            }

        
                return View();     //Acesso de pagina
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost] //Recebe o SUBMIT do formulário
        public IActionResult Register(ContaRegisterModel model)
        {
            //verificar se a model não possui erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var vendedorRepository = new VendedorRepository();
                    if (vendedorRepository.GetByEmail(model.Email) != null)
                    {
                        TempData["Mensagem"] = $"O email '{model.Email}' informado já está cadastrado para outro vendedor.";

                    }
                    else 
                    {
                        var vendedor = new Vendedor()
                        {
                            IdVendedor = Guid.NewGuid(),
                            Nome = model.Nome,
                            Email = model.Email,
                            Senha = model.Senha,
                            DataCriacao = DateTime.Now
                        };


                        vendedorRepository.Create(vendedor);

                        TempData["Mensagem"] = $"Parabéns {vendedor.Nome}, sua conta foi criada com sucesso!";
                        ModelState.Clear();

                    }


                  
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Erro: {e.Message}";
                }
            }

            return View(); //acessar a página
        }






        //ROTA: /Account/Password
        public IActionResult Password()
        {
            return View(); //acessar a página
        }


        [HttpPost]       // Recebe o submit do formulario
        public IActionResult Password(ContaPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //pesquisar o usuário no banco de dados através do email
                    var vendedorRepository = new VendedorRepository();
                    var vendedor = vendedorRepository.GetByEmail(model.Email);

                    if (vendedor != null)
                    {
                        #region Gerando uma nova senha para o usuário

                        var faker = new Faker();
                        var novaSenha = $"@{faker.Internet.Password()}";

                        #endregion

                        #region Enviando um email para o usuário contendo a nova senha

                        var subject = "Recuperação de Senha - Agenda de Contatos";
                        var body = @$"
                            <h3>Olá {vendedor.Nome}</h3>
                            <p>Uma nova senha foi gerada com sucesso para o seu usuário.</p>
                            <p>Acesse a agenda com a senha: <strong>{novaSenha}</strong></p>
                            <p>Após acessar a agenda, você poderá utilizar  o menu 'Minha Conta' para alterar sua senha.</p>
                            <br/>
                            <p>Att, <br/>Equipe Agenda de Contatos</p>
                        ";

                        var emailMessageService = new EmailMessageService();
                        emailMessageService.SendMessage(vendedor.Email, subject, body);

                        #endregion

                        #region Atualizando a senha no banco de dados

                        vendedorRepository.Update(vendedor.IdVendedor, novaSenha);

                        #endregion

                        TempData["Mensagem"] = "Uma nova senha foi gerada com sucesso, por favor verifiquesua conta de email.";

                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["Mensagem"] = "Email inválido. Usuário não encontrado.";
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"]= $"Falha ao recuperar senha: {e.Message}";
                }
            }

            return View(); //acessar a página
        }



        //ROTA: /Account/Logout
        public IActionResult Logout()
        {
            //apagar o cookie de autenticação
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirecionar de volta para a página de login
            return RedirectToAction("Login", "Canta"); //Account/Login
        }




    }

}

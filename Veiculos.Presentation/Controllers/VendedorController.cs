using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Veiculos.Data.Repositories;
using Veiculos.Presentation.Models;

namespace Veiculos.Presentation.Controllers
{
    [Authorize]
    public class VendedorController : Controller
    {
        public IActionResult MinhaConta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MinhaConta(VendedorMinhaContaModel model)
        {
            if ( ModelState.IsValid)
            {
                try
                {
                    //capturando os dados do Vendedor autenticado
                    var json = User.Identity.Name;
                    var auth = JsonConvert.DeserializeObject<AutenticacaoModel>(json);

                    //atualizando a senha do Vendedor no banco de dados
                    var vendedorRepository = new VendedorRepository();
                    vendedorRepository.Update(auth.IdVendedor, model.NovaSenha);

                   

                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = $"Ocorreu um erro: {e.Message}";
                }

            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário, por favor verifique.";

            }

            return View();
        }



    }
}

using AT02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT02.Controllers
{
    public class PacoteController : Controller
    {
        public IActionResult Alterar(){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        public IActionResult Cadastrar(){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        public IActionResult Deletar(){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                PacoteDatabase pd = new PacoteDatabase();
                pd.Excluir(id);
                ViewBag.feedbackdel = "Pacote deletado com sucesso";
                return View();
            }
            else
            {
                return View("Erro");
            }
            
        }

        public IActionResult Listar(){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            } 
        }
    }
}
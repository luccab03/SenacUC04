using AT02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT02.Controllers
{
    public class PacoteController : Controller
    {
        public IActionResult Alterar()
        {
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                ViewData["PacoteAlterado"] = null;
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpGet]
        public IActionResult Alterar(int IdPacote){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                PacoteDatabase db = new PacoteDatabase();
                Pacote pacote = db.Query(IdPacote);
                ViewData["PacoteAlterado"] = pacote;
                return View();
            }
            else
            {
                return View("Erro");
            }
        }


        [HttpPost]
        public IActionResult Alterar(Pacote pacote){
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                PacoteDatabase db = new PacoteDatabase();
                Pacote antigo = (Pacote) ViewData["PacoteAlterado"];
                pacote.IdCriador = antigo.IdCriador;
                pacote.IdPacote = antigo.IdPacote;
                db.Alterar(pacote);
                ViewData["PacoteAlterado"] = null;
                ViewBag.feedbackalt = "Pacote alterado com sucesso";
                return View();
            }
            else
            {
                return View("Erro");
            }
        } 

        public IActionResult Cadastrar()
        {
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
        public IActionResult Cadastrar(Pacote pacote)
        {
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                PacoteDatabase db = new PacoteDatabase();
                pacote.IdCriador = (int)HttpContext.Session.GetInt32("idUsuario");
                db.Inserir(pacote);
                ViewBag.feedbackcad = "Pacote cadastrado com sucesso";
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        public IActionResult Deletar()
        {
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
        public IActionResult Deletar(Pacote pacote)
        {
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                PacoteDatabase pd = new PacoteDatabase();
                pd.Excluir(pacote.IdPacote);
                ViewBag.feedbackdel = "Pacote deletado com sucesso";
                return View();
            }
            else
            {
                return View("Erro");
            }

        }

        public IActionResult Listar()
        {
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
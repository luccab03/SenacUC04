using AT02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
                Pacote old = db.Query(pacote.IdPacote);
                Pacote update = new Pacote();
                if(old.Nome != pacote.Nome && pacote.Nome != "") update.Nome = pacote.Nome; else update.Nome = old.Nome;
                if(old.Atrativos != pacote.Atrativos && pacote.Atrativos != "") update.Atrativos = pacote.Atrativos; else update.Atrativos = old.Atrativos;
                if(old.Destino != pacote.Destino && pacote.Destino != "") update.Destino = pacote.Destino; else update.Destino = old.Destino;
                if(old.Origem != pacote.Origem && pacote.Origem != "") update.Origem = pacote.Origem; else update.Origem = old.Origem;
                if(old.Retorno != pacote.Retorno && pacote.Retorno.ToString("MM/dd/yyyy") != "01/01/0001") update.Retorno = pacote.Retorno; else update.Retorno = old.Retorno;
                if(old.Saida != pacote.Saida && pacote.Saida.ToString("MM/dd/yyyy") != "01/01/0001") update.Saida = pacote.Saida; else update.Saida = old.Saida;
                update.IdCriador = old.IdCriador;
                update.IdPacote = old.IdPacote;
                db.Alterar(update);
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
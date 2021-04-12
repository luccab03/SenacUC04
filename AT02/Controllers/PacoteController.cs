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
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Zera os dados da página
                ViewData["PacoteAlterado"] = null;
                ViewBag.run = false;
                return View();
            }
            else
            {
                return View("Erro");
            }
        }
        
        [HttpGet]
        public IActionResult Alterar(int IdPacote)
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Verifica se o Id existe
                if (IdPacote != 0)
                {
                    // Cria uma instancia do db
                    PacoteDatabase db = new PacoteDatabase();
                    // Pega o pacote no db
                    Pacote pacote = db.Query(IdPacote);
                    // passa a ViewData com o pacote
                    ViewData["PacoteAlterado"] = pacote;
                }
                return View();
            }
            else
            {
                return View("Erro");
            }
        }


        [HttpPost]
        public IActionResult Alterar(Pacote pacote)
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                PacoteDatabase db = new PacoteDatabase();
                // Pega o pacote antigo no banco de dados
                Pacote old = db.Query(pacote.IdPacote);
                // Cria um novo pacote (futuro)
                Pacote update = new Pacote();
                // Verifica se o nome antigo é diferente do nome atual se sim ele atualiza no novo pacote
                if (old.Nome != pacote.Nome && pacote.Nome != "") update.Nome = pacote.Nome;
                else update.Nome = old.Nome;
                if (old.Atrativos != pacote.Atrativos && pacote.Atrativos != "") update.Atrativos = pacote.Atrativos;
                else update.Atrativos = old.Atrativos;
                if (old.Destino != pacote.Destino && pacote.Destino != "") update.Destino = pacote.Destino;
                else update.Destino = old.Destino;
                if (old.Origem != pacote.Origem && pacote.Origem != "") update.Origem = pacote.Origem;
                else update.Origem = old.Origem;
                if (old.Retorno != pacote.Retorno && pacote.Retorno.ToString("MM/dd/yyyy") != "01/01/0001")
                    update.Retorno = pacote.Retorno;
                else update.Retorno = old.Retorno;
                if (old.Saida != pacote.Saida && pacote.Saida.ToString("MM/dd/yyyy") != "01/01/0001")
                    update.Saida = pacote.Saida;
                else update.Saida = old.Saida;
                // Pega o id do criador e do pacote e bota no novo
                update.IdCriador = old.IdCriador;
                update.IdPacote = old.IdPacote;
                // Atualiza no db
                db.Alterar(update);
                // Zera a ViewData e avisa o usuario
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
            // Verifica se o usuario tem permissão para entrar na página
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
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                PacoteDatabase db = new PacoteDatabase();
                // Pega o id do usuario
                pacote.IdCriador = (int) HttpContext.Session.GetInt32("idUsuario");
                // Insere no db
                db.Inserir(pacote);
                // Da o feedback para o usuario
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
            // Verifica se o usuario tem permissão para entrar na página
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
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 1 || HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                PacoteDatabase pd = new PacoteDatabase();
                // Exclui o pacote do db
                pd.Excluir(pacote.IdPacote);
                // Da o feedback pro usuario
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
            // Verifica se o usuario tem permissão para entrar na página
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
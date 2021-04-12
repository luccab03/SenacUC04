using AT02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT02.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            // Cria uma instancia do db
            UsuarioDatabase ud = new UsuarioDatabase();
            // Verifica se o usuario existe (com nome e senha)
            if (ud.Query(usuario.Login) != null)
            {
                // Recupera o usuario do banco de dados
                Usuario userDb = ud.Query(usuario.Login);
                if (usuario.Senha == userDb.Senha)
                {
                    // Bota os dados na sessãp
                    HttpContext.Session.SetInt32("idUsuario", userDb.Id);
                    HttpContext.Session.SetString("nomeUsuario", userDb.Nome);
                    HttpContext.Session.SetString("loginUsuario", userDb.Login);
                    HttpContext.Session.SetString("senhaUsuario", userDb.Senha);
                    HttpContext.Session.SetInt32("tipoUsuario", userDb.Tipo);
                    HttpContext.Session.SetString("nascimentoUsuario", userDb.Nascimento.ToString("dd/mm/yyyy"));
                    // Redireciona para homepage
                    return Redirect("~/Home/Index");
                }
                else
                {
                    // Mensagem de feedback
                    ViewBag.mensagem = "Senha Incorreta";
                }
            }
            else
            {
                // Mensagem de feedback
                ViewBag.mensagem = "Usuario não encontrado";
            }

            return View();
        }

        public IActionResult Logout()
        {
            // Limpa a sessão e redireciona
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public IActionResult Cadastrar()
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        public IActionResult Lista()
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            // Cria uma instancia do db
            UsuarioDatabase ud = new UsuarioDatabase();
            // Insere o usuario no db
            ud.Insert(usuario);
            // Da o feedback
            ViewBag.mensagemc = "Cadastro efetuado com sucesso. Id do usuário = " + ud.Query(usuario.Login).Id;
            return View();
        }

        public IActionResult Alterar()
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpGet]
        public IActionResult Alterar(int id)
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                UsuarioDatabase ud = new UsuarioDatabase();
                // Busca no db com o Id e bota no ViewData
                ViewData["Alterado"] = ud.Query(id);
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Usuario user)
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                UsuarioDatabase ud = new UsuarioDatabase();
                // Altera o usuario no db
                ud.Alterar(user);
                // Zera a ViewBag
                ViewData["Alterado"] = null;
                // Feedback
                ViewBag.mensagema = "Usuário alterado com sucesso";
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
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                return View();
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            // Verifica se o usuario tem permissão para entrar na página
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                // Cria uma instancia do db
                UsuarioDatabase ud = new UsuarioDatabase();
                // Remove o id do db
                ud.Remover(id);
                // Feedback
                ViewBag.mensagemd = "Usuário deletado com sucesso!";
                return View();
            }
            else
            {
                return View("Erro");
            }
        }
    }
}
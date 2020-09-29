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
            UsuarioDatabase ud = new UsuarioDatabase();
            if (ud.Query(usuario.Login) != null)
            {
                Usuario userDb = ud.Query(usuario.Login);
                if (usuario.Senha == userDb.Senha)
                {
                    HttpContext.Session.SetInt32("idUsuario", userDb.Id);
                    HttpContext.Session.SetString("nomeUsuario", userDb.Nome);
                    HttpContext.Session.SetString("loginUsuario", userDb.Login);
                    HttpContext.Session.SetString("senhaUsuario", userDb.Senha);
                    HttpContext.Session.SetInt32("tipoUsuario", userDb.Tipo);
                    HttpContext.Session.SetString("nascimentoUsuario", userDb.Nascimento.ToString("dd/mm/yyyy"));
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ViewBag.mensagem = "Senha Incorreta";
                }
            }
            else
            {
                ViewBag.mensagem = "Usuario não encontrado";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public IActionResult Cadastrar()
        {
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
            UsuarioDatabase ud = new UsuarioDatabase();
            ud.Insert(usuario);
            ViewBag.mensagemc = "Cadastro efetuado com sucesso. Id do usuário = " + ud.Query(usuario.Login).Id;
            return View();
        }

        public IActionResult Alterar()
        {
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
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                UsuarioDatabase ud = new UsuarioDatabase();
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
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                UsuarioDatabase ud = new UsuarioDatabase();
                ud.Alterar(user);
                ViewData["Alterado"] = null;
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
            UsuarioDatabase ud = new UsuarioDatabase();
            if (HttpContext.Session.GetInt32("tipoUsuario") == 0)
            {
                ud.Remover(id);
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
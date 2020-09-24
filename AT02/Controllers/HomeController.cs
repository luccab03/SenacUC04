using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT02.Models;
using Microsoft.AspNetCore.Http;

namespace AT02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioDatabase ud = new UsuarioDatabase();
            if (ud.Query(usuario.Login) != null) {
                Usuario userDb = ud.Query(usuario.Login); 
                    if(usuario.Senha == userDb.Senha){
                        HttpContext.Session.SetInt32("idUsuario", userDb.Id);
                        HttpContext.Session.SetString("nomeUsuario", userDb.Nome);
                        HttpContext.Session.SetString("loginUsuario", userDb.Login);
                        HttpContext.Session.SetString("senhaUsuario", userDb.Senha);
                        HttpContext.Session.SetInt32("tipoUsuario", userDb.Tipo);
                        HttpContext.Session.SetString("nascimentoUsuario", userDb.Nascimento.ToString("dd/mm/yyyy"));
                        return Redirect("Index");
                    } else {
                        ViewBag.mensagem = "Senha Incorreta";
                    }
                } else {
                    ViewBag.mensagem = "Usuario não encontrado";
                }
            
            return View();
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return Redirect("Index");
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
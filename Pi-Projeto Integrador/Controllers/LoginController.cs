using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Pi_Projeto_Integrador.Contexts;
using Pi_Projeto_Integrador.Models;
using Pi_Projeto_Integrador.Utils;

namespace Pi_Projeto_Integrador.Controllers
{

    public class LoginController : Controller
    {
        private ControleEstoqueContext db;

        Util util = new Util();

        public LoginController(ControleEstoqueContext db_)
        {
            db_ = db ;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {

            try
            {
                var encryptedPassoword = util.Md5Encode(password);

                var user = db.cadUsuarios.Where(a => a.usuarioLogin == username && a.senha == encryptedPassoword).FirstOrDefault();

                if (user == null) throw new Exception("Usuário não encontrado ou senha incorreta");

                //preciso montar a logica dos cookies de autenticacao mas to com sono

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


           
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, username),
                //    new Claim(ClaimTypes.Role, "Admin") // Define a role do usuário
                //};

                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("index", "Home");


            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}

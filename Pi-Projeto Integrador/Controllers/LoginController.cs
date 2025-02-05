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
        public ControleEstoqueContext db = new ControleEstoqueContext();


        Util util = new Util();

        public LoginController(ControleEstoqueContext db_)
        {
            db = db_ ;

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
                password = util.Md5Encode(password);

                var user = db.cadUsuarios.Where(a => a.usuarioLogin == username && a.senha == password).FirstOrDefault();

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
            //    new Claim(ClaimTypes.Role, "Admin")
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

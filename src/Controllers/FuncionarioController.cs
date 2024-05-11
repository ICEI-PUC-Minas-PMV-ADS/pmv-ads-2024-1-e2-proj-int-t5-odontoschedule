using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoSchedule.Models;
using System.Security.Claims;

namespace OdontoSchedule.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly DBContext context;

        public FuncionarioController(DBContext context) {
            this.context = context;
        }

        [AllowAnonymous]
        public IActionResult LoginV()
        {
            return View("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login() {
            string conteudoArquivo;
            string[] usuarios;

            using(StreamReader sr = System.IO.File.OpenText("config.txt"))
            {
                conteudoArquivo = sr.ReadLine();
                usuarios = conteudoArquivo.Split(";");
            }

            foreach (string usuario in usuarios)
            {
                string usuarioNome = usuario.Split("=")[0];
                string usuarioSenha = usuario.Split("=")[1];

                if (usuarioNome == Request.Form["Usuario"])
                {
                    if(usuarioSenha == Request.Form["Senha"])
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, usuarioNome.ToUpper()),
                            new Claim(ClaimTypes.Role, usuarioNome.ToUpper())
                        };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        var authenticationProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                            IsPersistent = true,
                        };

                        await HttpContext.SignInAsync(claimsPrincipal, authenticationProperties);

                        return Ok(new { success = true, content = "" });
                    }
                    else
                    {
                        return Ok(new { success = false, content = "Senha incorreta" });
                    }
                }   
            }

            return Ok(new { success = false, content = "Usuário não encontrado" });
        }

        [Authorize(Roles = "SECRETARIA,ADMIN")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Paciente");
        }
    }

}

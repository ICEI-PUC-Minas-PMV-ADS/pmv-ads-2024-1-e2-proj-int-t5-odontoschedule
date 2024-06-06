using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdontoSchedule.Models;
using OdontoSchedule.Services;
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
                if (usuario.StartsWith("recuperacao_email"))
                {
                    continue;
                }

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

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ChangeRecoveryEmail()
        {
            string email = Request.Form["email"];
            string conteudoArquivo;
            List<string> configItens;
            string recuperacaoEmail;

            using (StreamReader sr = System.IO.File.OpenText("config.txt"))
            {
                conteudoArquivo = sr.ReadLine();
                configItens = conteudoArquivo.Split(";").ToList();
            }

            recuperacaoEmail = configItens.FirstOrDefault(item => item.StartsWith("recuperacao_email="));

            if (recuperacaoEmail == null)
            {
                return BadRequest("Erro ao ler o arquivo de configuração!");
            }

            configItens[configItens.IndexOf(recuperacaoEmail)] = "recuperacao_email=" + email;

            conteudoArquivo = String.Join(";", configItens);

            using (StreamWriter sw = new StreamWriter("config.txt"))
            {
                await sw.WriteAsync(conteudoArquivo);
            }

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "SECRETARIA,ADMIN")]
        public async Task<IActionResult> ChangePassword()
        {
            string novaSenha = Request.Form["senha"];
            string conteudoArquivo;
            string[] usuarios;
            int index = 0;

            using (StreamReader sr = System.IO.File.OpenText("config.txt"))
            {
                conteudoArquivo = sr.ReadLine();
                usuarios = conteudoArquivo.Split(";");
            }

            foreach (string usuario in usuarios)
            {
                if(usuario.StartsWith("recuperacao_email"))
                {
                    continue;
                }

                string usuarioNome = usuario.Split("=")[0];
                string usuarioSenha = usuario.Split("=")[1];


                if(User.IsInRole("SECRETARIA") && usuarioNome == "secretaria")
                {
                    usuarioSenha = novaSenha;

                    usuarios[index] = usuarioNome + "=" + usuarioSenha;

                    break;
                }

                if(User.IsInRole("ADMIN") && usuarioNome == "admin")
                {
                    usuarioSenha = novaSenha;

                    usuarios[index] = usuarioNome + "=" + usuarioSenha;

                    break;
                }

                index++;
            }

            conteudoArquivo = String.Join(";", usuarios);

            using(StreamWriter sw = new StreamWriter("config.txt"))
            {
                await sw.WriteAsync(conteudoArquivo);
            }

            return Ok(new { success = true, content = "" });
        }

        [Authorize(Roles = "SECRETARIA,ADMIN")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Paciente");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EsqueciMinhaSenhaC()
        {
            Random rand = new Random();
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int codelenght = 15;
            string code = "";
            string email = "";
            string conteudoArquivo;
            string recuperacaoEmail;
            List<string> configItens;

            using (StreamReader sr = System.IO.File.OpenText("config.txt"))
            {
                conteudoArquivo = sr.ReadLine();
                configItens = conteudoArquivo.Split(";").ToList();
            }

            recuperacaoEmail = configItens.FirstOrDefault(item => item.StartsWith("recuperacao_email="));

            if(recuperacaoEmail == null)
            {
                return BadRequest("Erro ao ler o arquivo de configuração!");
            }

            if(String.IsNullOrEmpty(recuperacaoEmail.Split("=")[1])) {
                return BadRequest("Email de recuperação não definido. Por favor, contate o suporte.");
            }
            else
            {
                email = recuperacaoEmail.Split("=")[1];
            }


            for (int i = 0; i < codelenght; i++)
            {
                code += chars[rand.Next(chars.Length)];
            }

            Recoverycode recoverycode = new Recoverycode();
            recoverycode.Code = code;
            recoverycode.PacienteId = null;
            this.context.RecoveryCodes.Add(recoverycode);

            await this.context.SaveChangesAsync();

            EmailSender.Send("Recuperacao de senha", "Segue o código e link de recuperação:\n\nLink: " + this.Url.Action("CriarNovaSenha", "Usuario", new { id = recoverycode.ID }, this.Request.Scheme) + "\nCódigo: " + code, email);

            return View("Login");
        }
    }

}

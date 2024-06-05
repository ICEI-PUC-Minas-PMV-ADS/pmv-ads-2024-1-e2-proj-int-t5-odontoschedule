
﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using OdontoSchedule.Services;
using System.Security.Claims;


namespace OdontoSchedule.Controllers
{
    public class PacienteController : Controller
    {
        private readonly DBContext context;

        public PacienteController(DBContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "SECRETARIA")]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Cadastro()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize(Roles = "PACIENTE")]
        public IActionResult Perfil()
        {
            ViewBag.Notificacoes = this.context.Notificacoes.Where(n => n.PacienteId == Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).ToList();

            return View(this.context.Pacientes.Find(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [Authorize(Roles = "ADMIN")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountByMonth()
        {
            Dictionary<int, int> patientsByMonth = await context.Pacientes
                    .GroupBy(p => new { DateTime.Today.Year, p.CriadoEm.Month })
                    .Select(g => new
                    {
                        month = g.Key.Month,
                        amount = g.Count()
                    })
                    .ToDictionaryAsync(x => x.month, x => x.amount);

            return Ok(patientsByMonth);

        }

        [Authorize(Roles = "SECRETARIA")]
        public IActionResult Index()
        {
            return View(this.context.Pacientes.ToList());
        }

        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> Details(int id)
        {
            Paciente paciente = await this.context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            ViewData["Atendimentos"] = await this.context.Atendimentos.Where((a) => a.PacienteId == id)
                .Include((a) => a.Dentista)
                .Include((a) => a.Agenda)
                    .ThenInclude((ag) => ag.Horario)
                .ToListAsync();

            return View(paciente);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email", "Senha")] Paciente paciente)
        {
            Paciente pacienteEncontrado = await this.context.Pacientes.Where((p) => p.Email == paciente.Email).FirstOrDefaultAsync();

            if (pacienteEncontrado == null)
            {
                return Ok(new { success = false, content = "Usuário não encontrado" });
            }

            if (BCrypt.Net.BCrypt.Verify(paciente.Senha, pacienteEncontrado.Senha))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, pacienteEncontrado.Nome),
                    new Claim(ClaimTypes.NameIdentifier, pacienteEncontrado.ID.ToString()),
                    new Claim(ClaimTypes.Role,"PACIENTE")
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


        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> ByCPF(string cpf)
        {
            List<Paciente> pacientes = await this.context.Pacientes.Where(p => p.CPF == cpf).ToListAsync();

            return pacientes.ToArray().Length > 0 ? Ok(pacientes.First()) : NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,CPF,Email,Telefone,Bairro,Cidade,Rua,Numero,Complemento,Senha")] Paciente paciente)
        {
            switch (Request.Form["sexo"])
            {
                case "true":
                    paciente.Sexo = true;
                    break;
                case "false":
                    paciente.Sexo = false;
                    break;
                default:
                    paciente.Sexo = null;
                    break;
            }

            if (ModelState.IsValid)
            {
                paciente.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Senha); //Criptografando a senha
                this.context.Add(paciente);
                await this.context.SaveChangesAsync();

                if (Request.Form["no_redirect"] == "true")
                {
                    return Ok(new { success = true, content = "" });
                }

                return RedirectToAction(nameof(Login));
            }

            if (Request.Form["no_redirect"] == "true")
            {
                return Ok(new { success = false, content = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                });
            }

            return View(nameof(Cadastro), paciente);
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,Nome,Senha,DataNascimento,CPF,Email,Telefone,Bairro,Cidade,Rua,Numero,Complemento")] Paciente paciente)
        {
            Paciente pacienteEncontrado = this.context.Pacientes.Find(paciente.ID);
            this.context.Entry(pacienteEncontrado).State = EntityState.Detached;

            if (pacienteEncontrado == null)
            {
                return NotFound();
            }

            if(User.IsInRole("SECRETARIA"))
            {
                paciente.Senha = pacienteEncontrado.Senha;
            }
            else
            {

                if (String.IsNullOrEmpty(paciente.Senha))
                {
                    paciente.Senha = pacienteEncontrado.Senha;
                }
                else
                {
                    paciente.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Senha);
                }
            }

            paciente.CriadoEm = pacienteEncontrado.CriadoEm;

            ModelState.Remove("Senha");
            ModelState.Remove("CriadoEm");

            switch (Request.Form["sexo"])
            {
                case "true":
                    paciente.Sexo = true;
                    break;
                case "false":
                    paciente.Sexo = false;
                    break;
                default:
                    paciente.Sexo = null;
                    break;
            }

            if (ModelState.IsValid)
            {
                this.context.Update(paciente);
                await this.context.SaveChangesAsync();

                if (User.IsInRole("SECRETARIA"))
                {
                    return RedirectToAction("Details", new { id = paciente.ID });
                }
                else
                {
                    return RedirectToAction("Perfil");
                }
                
            }
            else
            {
                Console.WriteLine(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            }


            if (User.IsInRole("SECRETARIA"))
            {
                ViewData["Atendimentos"] = await this.context.Atendimentos.Where((a) => a.PacienteId == paciente.ID)
                .Include((a) => a.Dentista)
                .Include((a) => a.Agenda)
                    .ThenInclude((ag) => ag.Horario)
                .ToListAsync();

                return View("Details", paciente);
            }
            else
            {
                return RedirectToAction("Perfil");
            }
        }

        [Authorize(Roles = "PACIENTE")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Paciente");
        }

        public ActionResult EsqueciMinhaSenha()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult EsqueciMinhaSenhaC()
        {
            string email = Request.Form["email"];
            Paciente paciente = this.context.Pacientes.Where(p => p.Email == email).FirstOrDefault();
            if (paciente == null) 
            { 
                return NotFound();
            }
            
            Random rand = new Random();
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int codelenght = 15;
            string code = "";

            for (int i = 0; i < codelenght; i++)
            {
                code += chars[rand.Next(chars.Length)];
            }

            Recoverycode recoverycode = new Recoverycode();
            recoverycode.Code = code;
            recoverycode.PacienteId = paciente.ID;
            this.context.RecoveryCodes.Add(recoverycode);

            EmailSender.Send("Recuperacao de senha", code, email);

            return View("Login");
        }
    }
}


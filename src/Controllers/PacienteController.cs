
﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
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


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email", "Senha")] Paciente paciente)
        {
            Paciente pacienteEncontrado = await this.context.Pacientes.Where((p) => p.Email == paciente.Email).FirstOrDefaultAsync();

            if(pacienteEncontrado == null)
            {
                return Ok(new { success = false, content = "Usuário não encontrado" });
            }
            
            if(BCrypt.Net.BCrypt.Verify(paciente.Senha, pacienteEncontrado.Senha))
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

                return Ok();
            }
            else
            {
                return Ok(new { success = false, content = "Senha incorreta" });
            }
        }


        public async Task<IActionResult> ByCPF(string cpf)
        {
            List<Paciente> pacientes = await this.context.Pacientes.Where(p => p.CPF == cpf).ToListAsync();
            
            return pacientes.ToArray().Length > 0 ?  Ok(pacientes.First()) : NotFound();
        }


	    [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,CPF,Email,Telefone,Bairro,Cidade,Rua,Numero,Complemento,Senha")] Paciente paciente)
        {
            switch(Request.Form["sexo"])
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

                return RedirectToAction(nameof(Login));
            }

            return View(paciente);
        }

    }
}


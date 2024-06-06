
﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using OdontoSchedule.Services;
using System.Security.Claims;


namespace OdontoSchedule.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DBContext context;

        public UsuarioController(DBContext context)
        {
            this.context = context;
        }

        public IActionResult CriarNovaSenha(int id)
        {
            Recoverycode recoverycode = this.context.RecoveryCodes.Find(id);

            if(recoverycode == null)
            {
                return NotFound();
            }

            ViewBag.idRecuperacao = id;
            ViewBag.ePaciente = recoverycode.PacienteId != null;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovaSenhaC()
        {
            Recoverycode recoverycode = this.context.RecoveryCodes.Find(Int32.Parse(Request.Form["id"]));

            if (recoverycode == null)
            {
                return NotFound();
            }

            if(recoverycode.Code == Request.Form["Codigo"]) {
                if(recoverycode.PacienteId != null)
                {
                    this.context.Entry(recoverycode).State = EntityState.Detached;

                    Paciente paciente = this.context.Pacientes.Find(recoverycode.PacienteId);

                    paciente.Senha = BCrypt.Net.BCrypt.HashPassword(Request.Form["Senha"]);

                    this.context.Pacientes.Update(paciente);

                    await this.context.SaveChangesAsync();

                    this.context.Entry(paciente).State = EntityState.Detached;

                    this.context.Remove(this.context.RecoveryCodes.Find(Int32.Parse(Request.Form["id"])));

                    await this.context.SaveChangesAsync();
                }
                else
                {
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
                        if (usuario.StartsWith("recuperacao_email"))
                        {
                            continue;
                        }

                        string usuarioNome = usuario.Split("=")[0];
                        string usuarioSenha = usuario.Split("=")[1];


                        if (Request.Form["funcionario"] == usuarioNome)
                        {
                            usuarioSenha = Request.Form["Senha"];

                            usuarios[index] = usuarioNome + "=" + usuarioSenha;

                            break;
                        }

                        index++;
                    }

                    conteudoArquivo = String.Join(";", usuarios);

                    using (StreamWriter sw = new StreamWriter("config.txt"))
                    {
                        await sw.WriteAsync(conteudoArquivo);
                    }

                    this.context.RecoveryCodes.Remove(recoverycode);
                    await this.context.SaveChangesAsync();
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


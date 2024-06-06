
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
            ViewBag.idRecuperacao = id;

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

            this.context.Entry(recoverycode).State = EntityState.Detached;

            if(recoverycode.Code == Request.Form["Codigo"]) {
                Paciente paciente = this.context.Pacientes.Find(recoverycode.PacienteId);

                paciente.Senha = BCrypt.Net.BCrypt.HashPassword(Request.Form["Senha"]);

                this.context.Pacientes.Update(paciente);

                await this.context.SaveChangesAsync();

                this.context.Entry(paciente).State = EntityState.Detached;

                this.context.Remove(this.context.RecoveryCodes.Find(Int32.Parse(Request.Form["id"])));

                await this.context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


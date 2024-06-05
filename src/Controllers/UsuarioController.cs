
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
    }
}


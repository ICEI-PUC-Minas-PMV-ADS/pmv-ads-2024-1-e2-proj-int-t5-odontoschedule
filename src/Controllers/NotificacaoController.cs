using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using System.Security.Claims;

namespace OdontoSchedule.Controllers
{
    [Authorize]
    public class NotificacaoController : Controller
    {
        private readonly DBContext context;


        public NotificacaoController(DBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return Ok(this.context.Notificacoes.Where(n => n.PacienteId == (User.FindFirstValue(ClaimTypes.Role) == "SECRETARIA" ? null : Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))).ToList()); 
        }
    }
}

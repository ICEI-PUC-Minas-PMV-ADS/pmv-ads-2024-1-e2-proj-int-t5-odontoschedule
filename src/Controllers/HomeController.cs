using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OdontoSchedule.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DBContext context;

        public HomeController(DBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            int atendimentosContagem;


            if(User.IsInRole("PACIENTE"))
            {
                atendimentosContagem = this.context.Atendimentos
                    .Include(a => a.Agenda)
                    .Include(a => a.Paciente)
                    .Where(a => DateOnly.FromDateTime(DateTime.Today.AddDays(1)) == a.Agenda.Data)
                    .Where(a => a.PacienteId == Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).Count();

                ViewBag.atendimentosContagem = atendimentosContagem;
            }
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

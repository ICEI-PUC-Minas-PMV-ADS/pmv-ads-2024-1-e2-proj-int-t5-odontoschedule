using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;

namespace OdontoSchedule.Controllers
{
    public class AgendaController : Controller
    {
        private readonly DBContext context;


        public AgendaController(DBContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        public IActionResult ByDentist(int dentista)
        {
            List<Agenda> agendas = new List<Agenda>();

            agendas = this.context.Agendas
                .Include(a => a.Horario)
                .Where(a => a.DentistaId == dentista)
                .OrderBy(a => a.Data)
                .ToList();

            return Ok(agendas);
        }
    }
}

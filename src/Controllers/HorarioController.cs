using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;

namespace OdontoSchedule.Controllers
{
    public class HorarioController : Controller
    {
        private readonly DBContext context;


        public HorarioController(DBContext context)
        {
            this.context = context;
        }

        //[Authorize(Roles = "SECRETARIA")]
        public IActionResult Index()
        {
            List<Horario> horarios = new List<Horario>();

            horarios = this.context.Horarios
                .OrderBy(a => a.Hora)
                .ToList();

            return Ok(horarios);
        }
    }
}

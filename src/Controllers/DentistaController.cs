using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;


namespace OdontoSchedule.Controllers
{
    public class DentistaController : Controller
    {
        private readonly DBContext context;

        public DentistaController(DBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return Ok(this.context.Dentistas.ToList<Dentista>());
        }
    }
}

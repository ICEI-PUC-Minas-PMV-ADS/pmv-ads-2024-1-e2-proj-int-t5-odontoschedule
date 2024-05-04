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

        // GET: AgendaController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ByDentist(int dentista)
        {
            List<Agenda> agendas = new List<Agenda>();

            agendas = this.context.Agendas
                .Include(a => a.Horario)
                .Where(a => a.DentistaId == dentista)
                .OrderBy(a => a.Data)
                .ToList<Agenda>();

            return Ok(agendas);
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}

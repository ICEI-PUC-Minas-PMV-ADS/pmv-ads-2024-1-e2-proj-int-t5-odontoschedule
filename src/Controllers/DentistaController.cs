using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;

namespace OdontoSchedule.Controllers
{
    public class DentistaController : Controller
    {
        private readonly DBContext _context;

        public DentistaController(DBContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dentistas.ToListAsync());
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Dentistas.ToListAsync());
        }

        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentista = await _context.Dentistas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dentista == null)
            {
                return NotFound();
            }

            return View(dentista);
        }

        [Authorize(Roles = "SECRETARIA")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "SECRETARIA")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,CPF,DataNascimento,CRO,Especialidade")] Dentista dentista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dentista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dentista);
        }

        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null)
            {
                return NotFound();
            }
            return View(dentista);
        }

        [Authorize(Roles = "SECRETARIA")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,CPF,DataNascimento,CRO,Especialidade")] Dentista dentista)
        {
            if (id != dentista.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dentista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DentistaExists(dentista.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dentista);
        }

        [Authorize(Roles = "SECRETARIA")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentista = await _context.Dentistas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dentista == null)
            {
                return NotFound();
            }

            return View(dentista);
        }

        [Authorize(Roles = "SECRETARIA")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista != null)
            {
                _context.Dentistas.Remove(dentista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SECRETARIA")]
        private bool DentistaExists(int id)
        {
            return _context.Dentistas.Any(e => e.ID == id);
        }
    }
}

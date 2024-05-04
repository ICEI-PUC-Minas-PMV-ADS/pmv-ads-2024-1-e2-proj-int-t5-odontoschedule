using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.T4Templating;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;


namespace OdontoSchedule.Controllers
{
    public class PacienteController : Controller
    {
        private readonly DBContext context;

        public PacienteController(DBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> ByCPF(string cpf)
        {
            List<Paciente> pacientes = await this.context.Pacientes.Where(p => p.CPF == cpf).ToListAsync();
            
            return pacientes.ToArray().Length > 0 ?  Ok(pacientes.First()) : NotFound();
        }
    }
}


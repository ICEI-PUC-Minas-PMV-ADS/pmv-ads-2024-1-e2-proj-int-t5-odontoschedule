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

        [Authorize(Roles = "SECRETARIA")]
        [HttpPost]
        public async Task<IActionResult> Create(List<string> horarios, string dentista, List<string> datas)
        {
            int index = 0;


            foreach (var item in horarios)
            {
                Agenda agenda = new Agenda();
                agenda.DentistaId = Int32.Parse(dentista);
                agenda.HorarioId = Int32.Parse(item);
                agenda.Data = DateOnly.Parse(datas[index]);

                this.context.Agendas.Add(agenda);

                index++;
            }

            await this.context.SaveChangesAsync();

            return Ok(new { success = true, content = "" });
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        public IActionResult ByDentist(int dentista)
        {
            List<Agenda> agendas = new List<Agenda>();

            var data_atual = DateOnly.FromDateTime(DateTime.Now);
            var primeiro_dia = data_atual.AddDays(-(int)data_atual.DayOfWeek);
            var ultimo_dia = primeiro_dia.AddDays(6);

            agendas = this.context.Agendas
                .Include(a => a.Horario)
                .Where(a => a.DentistaId == dentista)
                .Where(a => a.Data >= primeiro_dia && a.Data <= ultimo_dia)
                .OrderBy(a => a.Data)
                .ToList();

            return Ok(agendas);
        }

        [Authorize(Roles = "SECRETARIA")]
        [HttpPost]
        public async Task<IActionResult> Delete(List<string> agendas)
        {
            foreach (var item in agendas)
            {
                Agenda agenda = this.context.Agendas.Find(Int32.Parse(item));

                this.context.Agendas.Remove(agenda);
            }

            await this.context.SaveChangesAsync();

            return Ok(new { success = true, content = "" });
        }
    }
}

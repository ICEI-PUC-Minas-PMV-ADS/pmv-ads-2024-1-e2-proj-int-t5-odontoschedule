using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using System.Security.Claims;

namespace OdontoSchedule.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly DBContext context;


        public AtendimentoController(DBContext context) {
            this.context = context;   
        }

        public async Task<IActionResult> Index(bool status = false)
        {
            List<Atendimento> atendimentos = await this.context.Atendimentos
                .Include(a => a.Dentista)
                .Include(a => a.Paciente)
                .Include(a => a.Agenda)
                    .ThenInclude(h => h.Horario)
                .Where(a => a.Finalizado == status)
                .OrderBy(a => a.Agenda.Data)
                .ToListAsync();

            return View(atendimentos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(["TemConvenio", "DentistaId", "AgendaId", "PacienteId"])] Atendimento atendimento)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            Agenda agendaEncontrada = context.Agendas.Find(atendimento.AgendaId);

            if(User.FindFirstValue(ClaimTypes.Role) == "PACIENTE")
            {
                atendimento.PacienteId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            if (ModelState.IsValid)
            {
                if (agendaEncontrada.Disponivel)
                {
                    this.context.Add(atendimento);

                    try
                    {
                        agendaEncontrada.Disponivel = false;

                        this.context.Add(atendimento);
                        this.context.Update(agendaEncontrada);

                        await this.context.SaveChangesAsync();

                        response.Add("sucess", true);
                        response.Add("content", null);
                    }
                    catch (DbUpdateException)
                    {
                        response.Add("sucess", false);
                        response.Add("content", "Erro ao salvar as informações");
                    }
                }
                else
                {
                    response.Add("sucess", false);
                    response.Add("content", "Data e hora indisponível");
                }
            }
            else
            {
                string errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                response.Add("sucess", false);
                response.Add("content", errors);
            }

            return Ok(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            Atendimento atendimento =  await this.context.Atendimentos
                .Include(a => a.Dentista)
                .Include(a => a.Paciente)
                .Include(a => a.Agenda)
                    .ThenInclude(h => h.Horario)
                .FirstOrDefaultAsync(a => a.ID == id);

            if (atendimento == null) {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimento/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId", "Finalizado", "Observacoes")] Atendimento atendimento)
        {
            Atendimento atendimentoArmazenado = this.context.Atendimentos.Find(id);
            Dictionary<string, object> response = new Dictionary<string, object>();

            if (User.FindFirstValue(ClaimTypes.Role) == "PACIENTE")
            {
                atendimento.Finalizado = atendimentoArmazenado.Finalizado;
                atendimento.Observacoes = atendimentoArmazenado.Observacoes;
            }

            if (atendimentoArmazenado == null)
            {
                return NotFound();
            }

            if(atendimento.AgendaId == null)
            {
                response.Add("success", false);
                response.Add("content", "Agendamento inválido");

                return BadRequest(response);
            }

            if(atendimentoArmazenado.AgendaId != atendimento.AgendaId)
            {
                Agenda agendaMarcada = this.context.Agendas.Find(atendimentoArmazenado.AgendaId);
                Agenda novaAgenda = this.context.Agendas.Find(atendimento.AgendaId);

                if(agendaMarcada.DentistaId != novaAgenda.DentistaId)
                {
                    response.Add("success", false);
                    response.Add("content", "Não é possível fazer alteração do dentista responsável!");

                    return BadRequest(response);
                }

                if(!novaAgenda.Disponivel)
                {
                    response.Add("success", false);
                    response.Add("content", "Data e hora selecionados estão ocupados!");

                    return BadRequest(response);
                }


                agendaMarcada.Disponivel = true;
                novaAgenda.Disponivel = false;

                this.context.Agendas.Update(agendaMarcada);
                this.context.Agendas.Update(novaAgenda);
            }

            atendimentoArmazenado.AgendaId = atendimento.AgendaId;
            atendimentoArmazenado.Finalizado = atendimento.Finalizado;
            atendimentoArmazenado.Observacoes = atendimento.Observacoes;

            this.context.Atendimentos.Update(atendimentoArmazenado);
            await this.context.SaveChangesAsync();

            response.Add("success", true);
            response.Add("content", null);

            return RedirectToAction("Details", new { id });
        }

        // POST: Atendimento/Delete/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Atendimento atendimento = await this.context.Atendimentos.FindAsync(id);
            Dictionary<string, object> response = new Dictionary<string, object>();

            if (atendimento == null)
            {
                return NotFound();
            }

            if (atendimento.Finalizado)
            {
                response.Add("success", false);
                response.Add("content", "Você não pode cancelar um atendimento já concluído");

                return BadRequest(response);
            }

            Agenda agendaDoAtendimento = this.context.Agendas.Find(atendimento.AgendaId);
            agendaDoAtendimento.Disponivel = true;

            this.context.Agendas.Update(agendaDoAtendimento);
            this.context.Atendimentos.Remove(atendimento);
            await this.context.SaveChangesAsync();

            response.Add("success", true);
            response.Add("content", null);

            return Ok(response);
        }
    }
}

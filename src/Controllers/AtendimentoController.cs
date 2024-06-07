using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoSchedule.Models;
using System.Security.Claims;

namespace OdontoSchedule.Controllers
{
    [Authorize(Roles = "SECRETARIA,PACIENTE,ADMIN")]
    public class AtendimentoController : Controller
    {
        private readonly DBContext context;


        public AtendimentoController(DBContext context) {
            this.context = context;   
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetCountByModality()
        {
            return Ok(new { convenio = await this.context.Atendimentos.Where(a => a.TemConvenio == true).CountAsync(), particular = await this.context.Atendimentos.Where(a => a.TemConvenio == false).CountAsync() });
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        public async Task<IActionResult> Index(bool status = false, string tipo_filtro = null, string filtro_valor = null)
        {
            List<Atendimento> atendimentos;

            if(User.FindFirstValue(ClaimTypes.Role) == "SECRETARIA")
            {
                atendimentos = await this.context.Atendimentos
                    .Include(a => a.Dentista)
                    .Include(a => a.Paciente)
                    .Include(a => a.Agenda)
                        .ThenInclude(h => h.Horario)
                    .Where(a => a.Finalizado == status)
                    .OrderBy(a => a.Agenda.Data)
                    .ToListAsync();

                if(tipo_filtro != null && filtro_valor != null)
                {
                    switch (tipo_filtro.ToLower())
                    {
                        case "dentista":
                            atendimentos = atendimentos.Where(a => a.Dentista.Nome.Contains(filtro_valor) || a.Dentista.Nome.Equals(filtro_valor, StringComparison.CurrentCultureIgnoreCase)).ToList();
                            break;
                        case "data":
                            if (DateOnly.TryParse(filtro_valor, out DateOnly data_filtro))
                            {
                                atendimentos = atendimentos.Where(a => a.Agenda.Data == data_filtro).ToList();
                            }
                            break;
                        case "paciente":
                            atendimentos = atendimentos.Where(a => a.Paciente.Nome.Contains(filtro_valor) || a.Paciente.Nome.Equals(filtro_valor, StringComparison.CurrentCultureIgnoreCase)).ToList();
                            break;
                        default:
                            return BadRequest("Tipo de filtro inválido.");
                    }
                }
            }
            else
            {
                atendimentos = await this.context.Atendimentos
                    .Include(a => a.Dentista)
                    .Include(a => a.Paciente)
                    .Include(a => a.Agenda)
                        .ThenInclude(h => h.Horario)
                    .Where(a => a.Finalizado == status && a.Paciente.ID == Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    .OrderBy(a => a.Agenda.Data)
                    .ToListAsync();
            }

            return View(atendimentos);
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(["TemConvenio", "DentistaId", "AgendaId", "PacienteId"])] Atendimento atendimento)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            Agenda agendaEncontrada = context.Agendas.Find(atendimento.AgendaId);

            if(User.FindFirstValue(ClaimTypes.Role) == "PACIENTE")
            {
                ModelState.Remove("PacienteId");
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

                        if(User.FindFirstValue(ClaimTypes.Role) == "PACIENTE")
                        {
                            Notificacao notificacao = new Notificacao();
                            notificacao.PacienteId = null;
                            notificacao.Conteudo = "Uma novo atendimento foi registrado!";

                            this.context.Add(notificacao);
                        }

                        await this.context.SaveChangesAsync();

                        response.Add("success", true);
                        response.Add("content", null);
                    }
                    catch (DbUpdateException)
                    {
                        response.Add("success", false);
                        response.Add("content", "Erro ao salvar as informações");
                    }
                }
                else
                {
                    response.Add("success", false);
                    response.Add("content", "Data e hora indisponível");
                }
            }
            else
            {
                string errors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                response.Add("success", false);
                response.Add("content", errors);
            }

            return Ok(response);
        }

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
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


        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId", "Finalizado", "Observacoes")] Atendimento atendimento)
        {
            Atendimento atendimentoArmazenado = await this.context.Atendimentos.Include(a => a.Paciente).FirstOrDefaultAsync(a => a.ID == id);
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

                Notificacao notificacao = new Notificacao();
                notificacao.PacienteId = User.FindFirstValue(ClaimTypes.Role) == "PACIENTE" ? null : atendimentoArmazenado.Paciente.ID;
                notificacao.Conteudo = User.FindFirstValue(ClaimTypes.Role) == "PACIENTE" ? "Um atendimento foi remarcado" : "Um atendimento seu foi remarcado";

                this.context.Add(notificacao);
                this.context.Agendas.Update(agendaMarcada);
                this.context.Agendas.Update(novaAgenda);
            }

            if(atendimento.Finalizado && !atendimentoArmazenado.Finalizado)
            {
                Notificacao notificacao = new Notificacao();
                notificacao.PacienteId = atendimentoArmazenado.Paciente.ID;
                notificacao.Conteudo = "Um atendimento seu foi concluído";

                this.context.Add(notificacao);
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

        [Authorize(Roles = "SECRETARIA,PACIENTE")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Atendimento atendimento = await this.context.Atendimentos.Include(a => a.Paciente).FirstOrDefaultAsync(a => a.ID == id);
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

            Notificacao notificacao = new Notificacao();
            notificacao.PacienteId = User.FindFirstValue(ClaimTypes.Role) == "PACIENTE" ? null : atendimento.Paciente.ID;
            notificacao.Conteudo = User.FindFirstValue(ClaimTypes.Role) == "PACIENTE" ? "Um atendimento foi cancelado" : "Um atendimento seu foi cancelado";

            this.context.Add(notificacao);

            await this.context.SaveChangesAsync();

            response.Add("success", true);
            response.Add("content", null);

            return Ok(response);
        }

        public async Task<IActionResult> GetCountByStatus()
        {
            return Ok(new { concluido = await this.context.Atendimentos.Where(a => a.Finalizado == true).CountAsync(),
                pendente = await this.context.Atendimentos.Where(a => a.Finalizado == false).CountAsync() });
        }

        public async Task<IActionResult> GetCountByDay()
        {

            List<int> listaDias = new List<int> { 0, 0, 0, 0, 0, 0, 0 };

            List<Atendimento> listaAtendimentos = this.context.Atendimentos.Include(a => a.Agenda).ToList();

            foreach (var atendimento in listaAtendimentos)
            {
                listaDias[(int)atendimento.Agenda.Data.DayOfWeek]++;
            }

            return Ok(listaDias);

        }

    }
}

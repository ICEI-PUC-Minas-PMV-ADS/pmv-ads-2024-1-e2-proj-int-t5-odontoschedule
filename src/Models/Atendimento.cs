using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Atendimentos")]
    public class Atendimento
    {
        [Key]
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Obrigatório informar o status do atendimento")]
        public bool Finalizado { get; set; } = false;

        [MaxLength(400)]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se o paciente tem convênio!")]
        public bool TemConvenio { get; set; } = false;

        [Display(Name = "Dentista")]
        public int? DentistaId { get; set; }

        [Display(Name = "Agendamento")]
        public int? AgendaId { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Obrigatório informar o paciente a ser atendido!")]
        public int PacienteId { get; set; }

        [ForeignKey("DentistaId")]
        public Dentista Dentista { get; set; }

        [ForeignKey("AgendaId")]
        public Agenda Agenda { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }
    }
}

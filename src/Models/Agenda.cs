using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Obrigatório informar a data.")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a disponibilidade do dentista.")]
        public bool Disponivel { get; set; } = true;

        [Required(ErrorMessage = "Obrigatório informar o dentista.")]
        [Display(Name = "Dentista")]
        public int DentistaId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o horário.")]
        [Display(Name = "Horário")]
        public int HorarioId { get; set; }

        [ForeignKey("DentistaId")]
        public Dentista Dentista { get; set; }

        [ForeignKey("HorarioId")]
        public Horario Horario { get; set; }
    }
}

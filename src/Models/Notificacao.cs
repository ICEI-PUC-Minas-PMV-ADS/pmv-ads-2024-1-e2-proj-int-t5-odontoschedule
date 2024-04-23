using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Usuário")]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Obrigatório ter conteúdo na notificação.")]
        public string Conteudo { get; set; }
    }
}

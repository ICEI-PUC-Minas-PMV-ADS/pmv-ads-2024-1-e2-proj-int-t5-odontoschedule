using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Horarios")]
    public class Horario
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Obrigatório informar data e hora disponível.")]
        public TimeOnly Hora { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    public class Recoverycode
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        [ForeignKey ("PacienteId")]
        public Paciente Paciente { get; set; }

        public int PacienteId { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Dentistas")]
    public class Dentista
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(70)]
        [Required(ErrorMessage = "Obrigatório informar o nome do dentista.")]
        public string Nome { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "Obrigatório informar o CPF do dentista.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data de nascimento do dentista.")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Obrigatório informar o registro CRO do dentista.")]
        public string CRO { get; set; }

        [MaxLength(70)]
        [Required(ErrorMessage = "Obrigatório informar a especialidade do dentista.")]
        public string Especialidade { get; set; }
    }
}

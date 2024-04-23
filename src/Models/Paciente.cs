using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSchedule.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(60)]
        [Required(ErrorMessage = "O nome do paciente é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "O CPF do paciente é obrigatório")]
        public string CPF { get; set; }

        public bool Sexo { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "O email do paciente é obrigatório")]
        public string Email { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "O telefone do paciente é obrigatório")]
        public string Telefone { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "O bairro do paciente é obrigatório")]
        public string Bairro { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "A cidade do paciente é obrigatória")]
        public string Cidade { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "A rua do paciente é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número da residência do paciente é obrigatório")]
        public int Numero { get; set; }

        [MaxLength(20)]
        public string Complemento { get; set; }

        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A Senha do paciente é obrigatória")]
        public string Senha { get; set; }
    }
}

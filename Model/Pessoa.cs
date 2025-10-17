using System.ComponentModel.DataAnnotations;

namespace APITeste.Model
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public required string Nome { get; set; }

        [Required]
        public decimal Salario { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public required int Idade { get; set; }
        [MaxLength(9)]
        [Required]
        public required string Sexo { get; set; }

    }
}
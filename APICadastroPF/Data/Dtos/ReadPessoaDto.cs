using System.ComponentModel.DataAnnotations;

namespace APICadastroPF.Data.Dtos
{
    public class ReadPessoaDto
    {
        [Key]
        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }

        public DateTime HoraDaConsulta { get; set; }    
    }
}

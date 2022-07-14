using System.ComponentModel.DataAnnotations;

namespace APICadastroPF.Data.Dtos
{
    public class CreatePessoaDto
    {
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
    }
}

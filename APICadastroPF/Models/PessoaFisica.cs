using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICadastroPF.Models
{
    [Table("PessoaFisica")]
    public class PessoaFisica
    {
        [Column("Cpf")]
        [Key]
        [Required]
        public string Cpf { get; set; }
        [Column("Nome")]
        [Required]
        public string Nome { get; set; }
        [Column("Sobrenome")]
        [Required]
        public string Sobrenome { get; set; }
        [Column("Telefone")]
        [Required]
        public string Telefone { get; set; }
        [Column("Endereco")]
        [Required]
        public string Endereco { get; set; }
        
    }
}

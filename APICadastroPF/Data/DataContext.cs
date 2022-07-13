using APICadastroPF.Models;
using Microsoft.EntityFrameworkCore;

namespace APICadastroPF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
    }
}

using ControleMaquinas.models;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinas.DataContext                          //falar oque quero criar no banco de dados
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
                                                      //Qual model quero criar no banco de dados
        public DbSet<MaquinaModel> Maquinas { get; set; }
    }
}

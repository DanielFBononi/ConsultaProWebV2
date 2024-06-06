using ConsultaProWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb
{
    public class CPWDbContext : DbContext
    {
        public CPWDbContext(DbContextOptions<CPWDbContext> options) : base(options)
        {
          
        }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<MedicoEspecialidade> Medico_Especialidade { get; set; }

        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
       
    }
}

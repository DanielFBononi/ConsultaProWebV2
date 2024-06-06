using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public class MedEspRepository : IMedEspRepository
    {
        private readonly CPWDbContext _dbContext;

        public MedEspRepository(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MedicoEspecialidade CadastrarEspecialidade(MedicoEspecialidade especialidade)
        {
            _dbContext.Medico_Especialidade.Add(especialidade);
            _dbContext.SaveChanges();
            return especialidade;
        }

        public MedicoEspecialidade MedicoEspecialidade(int id)
        {
            return _dbContext.Medico_Especialidade.FirstOrDefault(x => x.Id_Medico == id);
        }
    }
}

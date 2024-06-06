using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly CPWDbContext _dbContext;
        public EspecialidadeRepository(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Especialidade AdicionarEspecialidade(Especialidade especialidade)
        {
            _dbContext.Especialidade.Add(especialidade);
            _dbContext.SaveChanges();
            return especialidade;
        }

        public List<Especialidade> GetEspecialidade()
        {
            return _dbContext.Especialidade.ToList();

        }

    }
}

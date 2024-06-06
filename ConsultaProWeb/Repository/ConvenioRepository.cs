using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public class ConvenioRepository : IConvenioRepository
    {
        private readonly CPWDbContext _dbContext;

        public ConvenioRepository(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Convenio AdicionarConvenio(Convenio convenio)
        {
            _dbContext.Convenio.Add(convenio);
            _dbContext.SaveChanges();
            return convenio;
        }

        public List<Convenio> GetConvenio()
        {
            return _dbContext.Convenio.ToList();
        }
    }
}

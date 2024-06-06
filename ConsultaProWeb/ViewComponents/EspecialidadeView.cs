using ConsultaProWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.ViewComponents
{
    public class EspecialidadeView : ViewComponent
    {
        private readonly CPWDbContext _dbContext;

        public EspecialidadeView(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            List<Especialidade> especialidade = _dbContext.Especialidade.ToList();


            return View("Especialidade", especialidade);

        }
    }
}

using ConsultaProWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.ViewComponents
{
    public class ConvenioView : ViewComponent
    {
        private readonly CPWDbContext _dbContext;

        public ConvenioView(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            List<Convenio> convenio = _dbContext.Convenio.ToList();

           
            return View("Convenio", convenio);

        }

    }
}

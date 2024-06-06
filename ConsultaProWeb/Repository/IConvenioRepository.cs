using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public interface IConvenioRepository
    {
        Convenio AdicionarConvenio(Convenio convenio);
        List<Convenio> GetConvenio();
    }
}

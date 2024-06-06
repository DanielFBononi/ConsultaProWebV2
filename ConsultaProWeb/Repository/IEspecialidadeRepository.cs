using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public interface IEspecialidadeRepository
    {
        Especialidade AdicionarEspecialidade(Especialidade especialidade);
        List<Especialidade> GetEspecialidade();
    }
}

using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public interface IMedEspRepository
    {
        MedicoEspecialidade MedicoEspecialidade(int id);
        MedicoEspecialidade CadastrarEspecialidade(MedicoEspecialidade especialidade);
    }
}

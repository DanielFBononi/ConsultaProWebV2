using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public interface IMedicoRepository
    {
        Medico BuscarMedico(string id);
        List<Medico> ListarMedicos();
        Medico AdicionarMedico(Medico medicousuario);
        Medico EditarMedico(int UserLogado, Medico medicousuario);
        bool ExcluirMedico(int Id);
    }
}

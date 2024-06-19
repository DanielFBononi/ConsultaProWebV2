using ConsultaProWeb.Models;

namespace ConsultaProWeb.Repository
{
    public interface IPacientesRepository
    {
        Pacientes AdicionarPaciente(Pacientes pacientes);
        List<Pacientes> ListarPacientes();
        Pacientes BuscarPaciente(string id);
        Pacientes EditarPaciente(int IdUserLogado, Pacientes pacientesusuario);
        bool ExcluirPaciente(int ID);
    }
}

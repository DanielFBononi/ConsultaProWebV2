using ConsultaProWeb.Models;

namespace ConsultaProWeb.Sessao
{
    public interface ISessao
    {
        void CriarSessaoDoPaciente(Pacientes paciente);
        void CriarSessaoDoMedico(Medico medico);
        void RemoverSessaoDoUsuario();
        Pacientes BuscarSessaoDoPaciente();
        Medico BuscarSessaoDoMedico();
    }
}

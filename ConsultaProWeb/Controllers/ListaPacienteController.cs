using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class ListaPacienteController : Controller
    {
        private readonly IPacientesRepository _pacienterepositorio;
        private readonly ISessao _sessao;

        public ListaPacienteController(IPacientesRepository pacienterepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _pacienterepositorio = pacienterepositorio;
        }
        public ActionResult ListaPaciente()
        {
            List<Pacientes> paciente = _pacienterepositorio.ListarPacientes();
            return View(paciente);
        }

    }
}

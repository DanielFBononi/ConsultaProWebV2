using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IMedicoRepository _medicorepositorio;
        private readonly ISessao _sessao;

        public AgendamentoController(IMedicoRepository medicorepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _medicorepositorio = medicorepositorio;
        }
        public ActionResult Index()
        {
           List<Medico> medico =  _medicorepositorio.ListarMedicos();
            return View(medico);
        }

        

    }
}

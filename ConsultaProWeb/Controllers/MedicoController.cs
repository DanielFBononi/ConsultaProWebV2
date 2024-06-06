using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicorepositorio;
        private readonly IMedEspRepository _medEspRespositorio;
        private readonly ISessao _sessao;

        public MedicoController(IMedicoRepository medicorepositorio, ISessao sessao, IMedEspRepository medEspRespositorio)
        {
            _sessao = sessao;
            _medicorepositorio = medicorepositorio;
            _medEspRespositorio = medEspRespositorio;
        }
        public IActionResult Index()
        {
            return View();


        }
        public IActionResult MedicoCadastro(Medico medico)
        {

            try
            {

                _medicorepositorio.AdicionarMedico(medico);
                return RedirectToAction("LoginMedico", "Login");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSÍVEL REALIZAR O CADASTRO: {erro.Message}";
                return RedirectToAction("Index","Home");
            }
        }
        public IActionResult MedicoDelete()
        {
            Medico medicologado = _sessao.BuscarSessaoDoMedico();
           
            try
            {
                _medicorepositorio.ExcluirMedico(medicologado.Id_Medico);
                _sessao.RemoverSessaoDoUsuario();


                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A EXCLUSÃO:{erro.Message}";
                return View("");
            }
        }

    }
}

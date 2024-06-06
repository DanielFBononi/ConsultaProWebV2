using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPacientesRepository _pacientesRepository;
        private readonly IMedicoRepository _medicorepositorio;
        private readonly ISessao _sessao;

        public LoginController(IMedicoRepository medicoRepositorio, IPacientesRepository pacientesRepositorio, ISessao sessao)
        {
            _pacientesRepository = pacientesRepositorio;
            _medicorepositorio = medicoRepositorio;
            _sessao = sessao;
        }

        public ActionResult LoginPaciente()
        {
            if (_sessao.BuscarSessaoDoPaciente() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult LoginMedico()
        {
            if (_sessao.BuscarSessaoDoMedico() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult EntrarPaciente(Users login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pacientes paciente = _pacientesRepository.BuscarPaciente(login.Email);

                    if (paciente != null)
                    {
                        if (paciente.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoPaciente(paciente);

                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                return View("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR O LOGIN:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult EntrarMedico(Users login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Medico medico = _medicorepositorio.BuscarMedico(login.Email);

                    if (medico != null)
                    {
                        if (medico.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoMedico(medico);

                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                return View("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR O LOGIN:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

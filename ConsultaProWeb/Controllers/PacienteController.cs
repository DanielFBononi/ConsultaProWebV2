using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class PacienteController : Controller
    {
            private readonly IPacientesRepository _pacienterepositorio;
            private readonly ISessao _sessao;

        public PacienteController(IPacientesRepository pacienterepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _pacienterepositorio = pacienterepositorio;
        }
        public IActionResult Index()
            {
                return View();


            }

        public IActionResult PacienteCadastro(Pacientes paciente)
        {
            
            try
            {
               
                    _pacienterepositorio.AdicionarPaciente(paciente);
                    return RedirectToAction("LoginPaciente", "Login");
               
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSÍVEL REALIZAR O CADASTRO: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult PacienteDelete()
            {
                Pacientes pacientelogado = _sessao.BuscarSessaoDoPaciente();
            
                try
                {
              
                    _pacienterepositorio.ExcluirPaciente(pacientelogado.Id_Paciente);
                    _sessao.RemoverSessaoDoUsuario();


                    return RedirectToAction("Index", "Home");
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A EXCLUSÃO:{erro.Message}";
                    return View("Index", "Home");
                }
            }
     

     
        public ActionResult PacienteEdit(Pacientes paciente)
        {
            try
            {
                Pacientes pacienteLogado = _sessao.BuscarSessaoDoPaciente();
                Pacientes Novopaciente = _pacienterepositorio.EditarPaciente(pacienteLogado.Id_Paciente, paciente);


                return RedirectToAction("Index", "Home");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"NÃO FOI POSSIVEL REALIZAR A ALTERAÇÃO NO USUARIO:{erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
    }




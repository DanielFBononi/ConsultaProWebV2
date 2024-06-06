using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
    public class EspecialidadeController : Controller
    {

        private readonly IEspecialidadeRepository _especialidadeRepositorio;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepositorio)
        {
            _especialidadeRepositorio = especialidadeRepositorio;
        }

        public IActionResult Index()
        {
            List<Especialidade> especialidades = _especialidadeRepositorio.GetEspecialidade();
            return View(especialidades);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialidade especialidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _especialidadeRepositorio.AdicionarEspecialidade(especialidade);
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel adicionar novos convenios: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

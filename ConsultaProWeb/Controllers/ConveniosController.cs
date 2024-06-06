using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaProWeb.Controllers
{
  
        public class ConveniosController : Controller
        {
            private readonly IConvenioRepository _convenioRepositorio;

            public ConveniosController(IConvenioRepository convenioRepositorio)
            {
                _convenioRepositorio = convenioRepositorio;
            }

            public IActionResult Index()
            {
                List<Convenio> convenios = _convenioRepositorio.GetConvenio();
                return View(convenios);
            }

            public IActionResult Create()
            {
                return View();
            }

           
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Convenio convenio)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _convenioRepositorio.AdicionarConvenio(convenio);
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


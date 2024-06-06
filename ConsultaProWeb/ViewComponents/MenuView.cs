using ConsultaProWeb.Models;
using ConsultaProWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsultaProWeb.ViewComponents
{
    public class MenuView : ViewComponent
    {
        private readonly IPacientesRepository _pacienteRepositorio;

        public MenuView(IPacientesRepository pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");



            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return View("MenuDeslogado");
            }
            Pacientes usuarioLogado = JsonConvert.DeserializeObject<Pacientes>(sessaoUsuario);
            Pacientes usuario = _pacienteRepositorio.BuscarPaciente(usuarioLogado.Email);

            return View("MenuLogado", usuario);
        }
    }
}

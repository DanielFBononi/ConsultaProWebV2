using Microsoft.AspNetCore.Http.Connections.Features;
using ConsultaProWeb.Models;
using Newtonsoft.Json;



namespace ConsultaProWeb.Sessao
{
  
        public class Sessao : ISessao
        {
            private readonly IHttpContextAccessor _httpContext;
            public Sessao(IHttpContextAccessor httpContext)
            {
                _httpContext = httpContext;
            }

            public Pacientes BuscarSessaoDoPaciente()
            {
                string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
                if (string.IsNullOrEmpty(sessaoUsuario)) return null;

                return JsonConvert.DeserializeObject<Pacientes>(sessaoUsuario);
            }
            public Medico BuscarSessaoDoMedico()
            {
                string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
                if (string.IsNullOrEmpty(sessaoUsuario)) return null;

                return JsonConvert.DeserializeObject<Medico>(sessaoUsuario);
            }

        public void CriarSessaoDoPaciente(Pacientes usuario)
            {
                string valor = JsonConvert.SerializeObject(usuario);
                _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
            }
            public void CriarSessaoDoMedico(Medico usuario)
            {
                string valor = JsonConvert.SerializeObject(usuario);
                _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
            }

            public void RemoverSessaoDoUsuario()
                {
                    _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
                }
            }
    }


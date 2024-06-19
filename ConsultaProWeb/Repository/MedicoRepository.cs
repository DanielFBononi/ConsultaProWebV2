using ConsultaProWeb.Models;
using ConsultaProWeb.Sessao;
using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly CPWDbContext _dbContext;
        private readonly IMedEspRepository _medEspRespositorio;
        

        
        public MedicoRepository(CPWDbContext dbContext, IMedEspRepository medEspRepositorio)
        {
            _medEspRespositorio = medEspRepositorio;
            _dbContext = dbContext;
        }
        public List<Medico> ListarMedicos()
        {

            return _dbContext.Medico.ToList();
        }

        public Medico BuscarMedico(string email)
        {
            return _dbContext.Medico.FirstOrDefault(x => x.Email == email);
        }


        public Medico AdicionarMedico(Medico medicousuario)
        {

            

            _dbContext.Medico.Add(medicousuario);
            _dbContext.SaveChanges();

            Medico Nomemedico = BuscarMedico(medicousuario.Email);

            MedicoEspecialidade medicoEspecialidade = new MedicoEspecialidade();
            medicoEspecialidade.Id_Med_Esp = 0;
            medicoEspecialidade.Id_Medico = Nomemedico.Id_Medico;
            medicoEspecialidade.Id_Especialidade = Nomemedico.Id_Especialidade;
            _dbContext.Medico_Especialidade.Add(medicoEspecialidade);

            _dbContext.SaveChanges();
            return medicousuario;
        }

        public Medico EditarMedico(int idUser, Medico medicousuario)
        {
            Medico medicousuariodb =  _dbContext.Medico.FirstOrDefault(x => x.Id_Medico == idUser);
       
          
            if (medicousuariodb == null)
            {
                throw new Exception("Nao e possivel alterar o usuarrio");
            }
          

            medicousuariodb.Nome = medicousuario.Nome;
            medicousuariodb.Email = medicousuario.Email;
            medicousuariodb.Consultorio = medicousuario.Consultorio;
            medicousuariodb.RuaAvenida = medicousuario.RuaAvenida;
            medicousuariodb.Numero = medicousuario.Numero;
            medicousuariodb.CEP = medicousuario.CEP;
            medicousuariodb.Bairro = medicousuario.Bairro;

            _dbContext.Medico.Update(medicousuariodb);
            _dbContext.SaveChanges();
            return medicousuariodb;
        }

        public bool ExcluirMedico(int idUser)
        {

            Medico medicousuariodb = _dbContext.Medico.FirstOrDefault(x => x.Id_Medico == idUser);
            MedicoEspecialidade medicoEspecialidade = _medEspRespositorio.MedicoEspecialidade(medicousuariodb.Id_Medico);
            if (medicousuariodb == null)
            {
                throw new Exception("Nao e possivel alterar o usuarrio");
            }

            _dbContext.Medico_Especialidade.Remove(medicoEspecialidade);
            _dbContext.SaveChanges();
            _dbContext.Medico.Remove(medicousuariodb);
            _dbContext.SaveChanges();

            return true;
        }

        
    }
}

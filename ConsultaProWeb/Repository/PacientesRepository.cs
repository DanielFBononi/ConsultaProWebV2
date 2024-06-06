using ConsultaProWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb.Repository
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly CPWDbContext _dbContext;

        public PacientesRepository(CPWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pacientes BuscarPaciente(string email)
        {

            return _dbContext.Pacientes.FirstOrDefault(x => x.Email == email);
        }

        public List<Pacientes> ListarPacientes()
        {

            return _dbContext.Pacientes.ToList();
        }
        public Pacientes AdicionarPaciente(Pacientes pacientes)
        {
            _dbContext.Pacientes.Add(pacientes);
            _dbContext.SaveChanges();
            return pacientes;
        }
        public Pacientes EditarPaciente(int id, Pacientes pacientesusuario)
        {
            Pacientes pacienteusuariodb = _dbContext.Pacientes.FirstOrDefault(x => x.Id_Paciente == id);
            
            if (pacienteusuariodb == null)
            {
                throw new Exception("Nao e possivel alterar o usuario");
            }


            pacienteusuariodb.Nome = pacientesusuario.Nome;
            pacienteusuariodb.DataNascimento = pacientesusuario.DataNascimento;
            pacienteusuariodb.Email = pacientesusuario.Email;
            pacienteusuariodb.Telefone = pacientesusuario.Telefone;
            pacienteusuariodb.Senha = pacientesusuario.Senha;
           

            _dbContext.Pacientes.Update(pacienteusuariodb);
            _dbContext.SaveChanges();
            return pacienteusuariodb;
        }

        public bool ExcluirPaciente(int Id)
        {
           Pacientes paciente = _dbContext.Pacientes.FirstOrDefault(x => x.Id_Paciente == Id);

            if (paciente == null)
            {
                throw new Exception("Nao foi possivel deletar a conta");
            }
          

            _dbContext.Pacientes.Remove(paciente);
            _dbContext.SaveChanges();
            return true;
        }

       
    }
}
       

       
      

   
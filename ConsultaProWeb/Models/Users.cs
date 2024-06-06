using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb.Models
{
    [Keyless]
    public class Users
    {

        public int Id_User { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Medico { get; set; }

        public int Id_User_Nivel { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}

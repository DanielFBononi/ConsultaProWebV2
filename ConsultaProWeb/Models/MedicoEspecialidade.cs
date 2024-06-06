using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsultaProWeb.Models
{
    

    
    public class MedicoEspecialidade
    {
        [Key]
        public int Id_Med_Esp { get; set; }
        public int Id_Medico { get; set; }
        public int Id_Especialidade { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb.Models
{
    [Keyless]

    public class Especialidade
    {
        public int Id_Especialidade { get; set; }
        public string  especialidade { get; set; }
    }
}

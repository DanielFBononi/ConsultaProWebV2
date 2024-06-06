using Microsoft.EntityFrameworkCore;


namespace ConsultaProWeb.Models
{
    [Keyless]
    public class Convenio
    {
        public int Id_Convenio { get; set; }
        public string Nome { get; set; }
    }
}

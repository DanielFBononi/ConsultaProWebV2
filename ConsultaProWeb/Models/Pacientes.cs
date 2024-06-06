using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsultaProWeb.Models
{
    
    public class Pacientes
    {
        [Key]
        public int Id_Paciente { get; set; }

        [Required(ErrorMessage = "O campo Nome e obrigatorio, coloque seu nome completo")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Nome { get; set;}

        [Required(ErrorMessage = "O campo Data de nascimento e obrigatorio")]
        public DateTime DataNascimento { get; set; }

        public int  ConvenioID { get; set; }

        [Required(ErrorMessage = "O campo Email e obrigatorio, coloque seu Email completo")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Email{ get; set; }

        [Required(ErrorMessage = "O campo Telefone e obrigatorio, coloque seu nome completo")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 numeros e no maximo 20 ")]

        public string Telefone { get; set; }

        public string Senha { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}

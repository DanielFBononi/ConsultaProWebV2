using System.ComponentModel.DataAnnotations;

namespace ConsultaProWeb.Models
{
    public class Medico
    {
        [Key]

        public int Id_Medico { get; set; }
        [Required (ErrorMessage ="O Campo CRM e obrigatorio")]
        [StringLength(7, MinimumLength = 7 , ErrorMessage ="Deve conter no minimo e maximo 8 numeros e/ou letras")]
        public string CRM { get; set;}
       
        public int Id_Especialidade { get; set;}
        [Required (ErrorMessage = "O campo nome e obrigatorio, coloque seu nome completo")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Nome { get; set;}
        [Required(ErrorMessage = "O campo email e obrigatorio, coloque seu email completo")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Email { get; set; }
        public string Senha { get; set;}
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Consultorio { get; set;}
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]


        public string RuaAvenida { get; set;}
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Deve conter no minimo 2 caracter e no maximo 10 ")]

        public string Numero { get; set;}
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Deve conter no minimo 10 caracter e no maximo 10 ")]

        public string CEP { get; set;}
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter no minimo 5 caracter e no maximo 100 ")]

        public string Bairro { get; set;}
        public int ConvenioID { get; set;}



        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}

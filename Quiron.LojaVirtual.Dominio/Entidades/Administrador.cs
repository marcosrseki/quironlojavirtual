using System;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Administrador
    {
        //Indica que é a chave primária
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o login")]
        [Display(Name = "Login:")] //Mostra o texto dentro do campo de login
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [Display(Name = "Senha:")]
        [DataType(DataType.Password)] //Oculta os caracteres da senha
        public string Senha { get; set; }

        public Nullable<DateTime> UltimoAcesso { get; set; }
    }
}

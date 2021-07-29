using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Board.Models
{
    public class VM_Login
    {
        [DisplayName("Usuario de dominio")]
        [Required(ErrorMessage = "Usuario@Domain es requerido.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="Domain inv�lido.")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password es requerida.")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
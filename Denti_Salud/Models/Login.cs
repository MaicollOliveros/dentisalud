using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Denti_Salud.Models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
      //[StringLength(18, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
      //[RegularExpression(@"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$", ErrorMessage ="La contraseña debe tener al entre 8 y 15 caracteres, al menos un dígito, al menos una minúscula, al menos una mayúscula y al menos un caracter no alfanumérico.")]
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}

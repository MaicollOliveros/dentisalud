using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Password { get; set; }
        
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email no valido.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Rol es requerido")]
        [RolValidacion(ErrorMessage = "El role debe ser pcn, odn, rcp, adm")]
        public string Role { get; set; }
    }
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public UserViewModel(User user)
        {
            UserName = user.UserName;
            Name = user.Name;
            MobilePhone = user.MobilePhone;
            Email = user.Email;
            Role = user.Role;
        }

    }
}
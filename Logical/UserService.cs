using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class UserService
    {
        private readonly DentisaludContext _context;
        public UserService(DentisaludContext contex)
        {
            _context = contex;
        }
        public User Validate(string userName, string password)
        {
            return _context.Users.FirstOrDefault(t => t.UserName == userName && t.Password == password);
        }
        public ResponseUser GuardarUser(User user)
        {
            try
            {
                var userBuscado = _context.Users.Find(user.UserName);
                if (userBuscado != null)
                {
                    return new ResponseUser("Error, el usuario ingresao ya se encuentra registrado");
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResponseUser(user);
            }
            catch (System.Exception ex)
            {
                return new ResponseUser("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }
        public ResponseUser ConsultarUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                return new ResponseUser(users);
            }
            catch (System.Exception ex)
            {
                return new ResponseUser("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }
    }
    public class ResponseUser
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseUser(User user)
        {
            User = user;
            Error = false;
        }

        public ResponseUser(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseUser(List<User> users)
        {
            Users = users;
            Error = false;
        }

    }
}

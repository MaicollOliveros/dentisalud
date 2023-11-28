using Datos;
using Denti_Salud.Config;
using Denti_Salud.Models;
using Denti_Salud.Service;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Denti_Salud.Controllers
{
     [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private JwtService _jwtService;
        private UserService _userService;

        DentisaludContext _context;
        public LoginController(DentisaludContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            var admin = _context.Users.Find("admon");
            if (admin == null)
            {
                _context.Users.Add(new User() { 
                    UserName = "admon", 
                    Password = "admon", 
                    Email = "admin@gmail.com", 
                    Name = "Juanchito", 
                    MobilePhone = "3217212918",
                    Role = "adm",
                });
                var i = _context.SaveChanges();
            }
            _jwtService = new JwtService(appSettings);
            _userService = new UserService(context);
        }



        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _userService.Validate(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Username or password is incorrect");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _jwtService.GenerateToken(user);

            return Ok(response);
        }




    [HttpPost("/Usuario")]
    [Route("Usuario")]
    public ActionResult<PacienteViewModel> postUser(UserInputModel userInput)
    {
      var user = this.MapearUser(userInput);
      var response = _userService.GuardarUser(user);
      if (response.Error)
      {
        ModelState.AddModelError("Guardar usuario", response.Mensaje);
        var problemDetais = new ValidationProblemDetails(ModelState)
        {
          Status = StatusCodes.Status400BadRequest,
        };
        return BadRequest(problemDetais);
      }

      var userView = new UserViewModel(user);
      return Ok(userView);
    }

    private User MapearUser(UserInputModel userInput)
    {
      var user = new User()
      {
        UserName = userInput.UserName,
        Name = userInput.Name,
        Password = userInput.Password,
        Email = userInput.Email,
        Role = userInput.Role,
      };
      return user;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserViewModel>> GetPacientes()
    {
      var response = _userService.ConsultarUsers();
      if (!response.Error)
      {
        var userView = response.Users.Select(p => new UserViewModel(p));
        return Ok(userView);
      }
      return BadRequest(response.Mensaje);
    }

    }
}

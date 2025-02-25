using Product_Management_API.Models;
using Product_Management_API.Repository;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Product_Management_API.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.LoginRequest obj)
        {
            if (obj.UserName == null && obj.Password == null)
            {
                return Unauthorized(new { success = false, message = "Please provide Username and password" });
            }
            var jwtToken = _authRepository.Login(obj);
            return Ok( new {success = true,token = jwtToken,message ="successfully logged in" });
        }

        

        [HttpPost("addUser")]
        public User AddUser([FromBody] UserDTO user)
        {
            var addedUser = _authRepository.AddUser(user);
            return addedUser;
        }

      

    }
}

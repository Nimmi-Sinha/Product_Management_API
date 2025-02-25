using Product_Management_API.Data;
using Product_Management_API.Models;
using Product_Management_API.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Product_Management_API.DTO;

namespace Product_Management_API.Service
{
    public class AuthService: IAuthRepository
    {
        private readonly AppDbContext _appContext;
        private readonly IConfiguration _configuration; 

        public AuthService(AppDbContext appContext, IConfiguration configuration)
        {
            _appContext = appContext;
            _configuration = configuration;
        }

       

        public User AddUser(UserDTO userDto)
        {
            var user = new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Password = userDto.Password,
                UserName = userDto.UserName,
                Role = userDto.Role
            };

            var addedUser = _appContext.Users.Add(user);
            _appContext.SaveChanges();
            return addedUser.Entity;
        }

    

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.UserName != null && loginRequest.Password != null)
            {
                var user = _appContext.Users.SingleOrDefault(
                    s => s.UserName == loginRequest.UserName
                    && s.Password == loginRequest.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id",user.Id.ToString()),
                        new Claim("UserName",user.UserName),
                    };
                    //var userRoles = _appContext.UserRoles.Where(u => u.UserId == user.Id).ToList();
                    var userRoles = _appContext.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).ToList();
                    //var roleIds = userRoles.Select(s => s.RoleId).ToList();
                   // var roles = _appContext.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
                    foreach (var role in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Role));
                    }
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                         _configuration["Jwt:Audience"],
                         claims,
                         expires: DateTime.UtcNow.AddMinutes(10),
                         signingCredentials: signIn);
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid");
                }
            }
            else {
                throw new Exception("Credential are not valid");
            }

        }
    }
}

using Product_Management_API.DTO;
using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public interface IAuthRepository
    {
        User AddUser (UserDTO user);
        string Login(LoginRequest loginRequest);
    }
}

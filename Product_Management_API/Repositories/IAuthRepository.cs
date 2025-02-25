using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public interface IAuthRepository
    {
        User AddUser (User user);
        string Login(LoginRequest loginRequest);

        Role AddRole(Role role);

        bool AssignRoleToUser(AddUserRole obj);
    }
}

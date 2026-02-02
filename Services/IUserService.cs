using DTOs;
using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(User user);
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> LogIn(User user);
        Task<bool> UpdateUser(User user, int id);
    }
}
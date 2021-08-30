using System;
using System.Threading.Tasks;
using StoreManagement.DB;

namespace StoreManagement.BL
{
    public interface IUserService
    {
        Task<bool> UpdateUser(string userId, UpdateUserRequest updateUser);
        Task<bool> DeleteUser(string userId);
        Task<UserResponseDTO> GetUser(string userId);
    }
}
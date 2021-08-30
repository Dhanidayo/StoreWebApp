using System;
using System.Threading.Tasks;
using StoreManagement.DB;

namespace StoreManagement.BL
{
    public interface IAuthentication
    {
        Task<UserResponseDTO> Register(RegistrationRequest registrationRequest);
        Task<UserResponseDTO> Login(UserRequest userRequest);
    }
}
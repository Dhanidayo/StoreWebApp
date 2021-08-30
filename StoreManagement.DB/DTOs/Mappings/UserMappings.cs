using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class UserMappings
    {
        public static UserResponseDTO GetUserResponse(User user)
        {
            return new UserResponseDTO
            {
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id
            };
        }

        public static User GetUser(RegistrationRequest request)
        {
            return new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName,
            };
        }
    }
}
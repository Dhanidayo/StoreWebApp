using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using StoreManagement.Models;
using StoreManagement.DB;
using Microsoft.AspNetCore.Identity;

namespace StoreManagement.BL
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        
        public Authentication(UserManager<User> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserResponseDTO> Register(RegistrationRequest registrationRequest)
        {
            User user = UserMappings.GetUser(registrationRequest);

            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                return UserMappings.GetUserResponse(user);
            }

            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }

            throw new MissingFieldException(errors);
        }

        public async Task<UserResponseDTO> Login(UserRequest userRequest)
        {
            User user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    var response = UserMappings.GetUserResponse(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);

                    return response;
                }

                throw new AccessViolationException("Invalid Credentials");
            }

            throw new AccessViolationException("Invalid Credentials");
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StoreManagement.DB;
using StoreManagement.BL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserRequest userRequest)
        {
            try
            {
                return Ok(await _authentication.Login(userRequest));
            }
            catch (AccessViolationException)
            {          
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequest registrationRequest)
        {
            try
            {
                var result = await _authentication.Register(registrationRequest);
                return Created("", result);
            }
            catch (MissingFieldException msex)
            {
                
                return BadRequest(msex.Message);
            }
            catch (Exception) //catch unforseen exceptions.
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using InnoTech.LegosForLife.Security;
using InnoTech.LegosForLife.Security.IServices;
using InnoTech.LegosForLife.Security.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public AuthController(ISecurityService securityService)
        {
            _securityService = securityService;
        }
        // /api/auth/login - POST - Body - Username: string, Password: string - Return token and message
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            try
            {
                var token = _securityService.GenerateJwtToken(dto.Username, dto.Password);
                return Ok(new TokenDto
                {
                    Jwt = token.Jwt,
                    Message = token.Message
                });
            }
            catch (AuthenticationException ae)
            {
                return Unauthorized(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Please contact Admin");
            }
        }

        [HttpPost]
        public ActionResult<AuthUserDto> Create([FromBody] CreateAuthUserDto dto)
        {
            try
            {
                var authUser = _securityService.GenerateNewAuthUser(dto.Username);
                return Ok(new AuthUserDto
                {
                    Id = authUser.Id,
                    Username = authUser.UserName
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Contact Admin!");
            }
            
        }
    }

    public class CreateAuthUserDto
    {
        public string Username { get; set; }
    }

    public class AuthUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
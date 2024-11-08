using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Filters;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Models.DTO.Auth;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterAddRequest register)
        {
            var identityUser = new IdentityUser() { UserName = register.UserName, Email = register.UserName };
            if (string.IsNullOrEmpty(register.Password))
            {
                // Handle the case where the password is null or empty
                return BadRequest("Password cannot be null or empty");
            }

            var identityResult = await _userManager.CreateAsync(identityUser, register.Password);
            if (identityResult.Succeeded)
            {
                if (register.Roles != null && register.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, register.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User created successfully");
                    }
                }
            }

            return BadRequest("Something went wrong...");
        }

        [HttpPost("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!string.IsNullOrEmpty(loginRequestDto.Username) && !string.IsNullOrEmpty(loginRequestDto.Password))
            {
                var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
                if (user != null)
                {
                    var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                    if (isPasswordValid)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles != null)
                        {
                            var token = _tokenRepository.CreateJwTToken(user, roles.ToList());
                            var response = new LoginResponseDto() { JwtToken = token, };
                            return Ok(response);
                        }
                    }
                }
            }

            return BadRequest("Username or password is incorrect");
        }
    }
}

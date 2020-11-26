using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.DTOs;
using Common.Contracts;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using API.Extensions;
using System.Security.Claims;

namespace API.Controllers
{
    /// <summary>  
    ///  This controller class defines the set of endpoints
    ///  available to authenticate members and complete Oauth
    ///  workflow.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;

        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        // POST api/[controller]/login
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<JsonWebTokenDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            ResponseDto<JsonWebTokenDto> okResponse = new ResponseDto<JsonWebTokenDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                okResponse.Data = await _authentication.LoginUserAsync(loginDto);
                return Ok(okResponse);
            }
            catch (AuthenticationException ex)
            {
                errorResponse.Data = new ErrorDto(ex.Message);
                return BadRequest(errorResponse);
            }

        }

        // POST api/[controller]/register
        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<JsonWebTokenDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
        {
            ResponseDto<JsonWebTokenDto> okResponse = new ResponseDto<JsonWebTokenDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                okResponse.Data = await _authentication.RegisterUserAsync(registrationDto);
                return Ok(okResponse);
            }
            catch (AuthenticationException ex)
            {
                errorResponse.Data = new ErrorDto(ex.Message);
                return BadRequest(errorResponse);
            }
            catch (DbUpdateException ex)
            {
                if (ex.Message.ToLower().Contains("inner exception"))
                {
                    if (ex.InnerException.Message.ToLower().Contains("email") && ex.InnerException.Message.ToLower().Contains("duplicate"))
                    {
                        int at = ex.InnerException.Message.IndexOf("@");
                        string[] words = ex.InnerException.Message.Split(" ");
                        errorResponse.Data = new ErrorDto("Email already exists. Try reseting the paasword (this is expected if you joined our slack group).");
                    }
                    else
                    {
                        errorResponse.Data = new ErrorDto(ex.Message);
                    }
                }
                else
                {
                    errorResponse.Data = new ErrorDto(ex.Message);
                }

                return BadRequest(errorResponse);
            }
        }

        // POST api/[controller]/change-password
        [HttpPost("change-password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
#if !DEBUG
        [Authorize]
#endif
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            string userId = HttpContext.User.Identity.GetUserId();

            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                await _authentication.ChangePassword(userId, changePassword);
                return Ok();
            }
            catch (AuthenticationException ex)
            {
                errorResponse.Data = new ErrorDto(ex.Message);
                return BadRequest(errorResponse);
            }

        }

        // POST api/[controller]/reset-password-request
        [HttpPost("reset-passsword-request")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> ResetPasswordRequest([FromBody] ResetPasswordRequestDto resetPasswordRequest)
        {
            await _authentication.ResetPasswordRequest(resetPasswordRequest);
            return Ok();
        }

        // POST api/[controller]/reset-password
        [HttpPost("reset-passsword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPassword)
        {
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                await _authentication.ResetPassword(resetPassword);
                return Ok();
            }
            catch (AuthenticationException ex)
            {
                errorResponse.Data = new ErrorDto(ex.Message);
                return BadRequest(errorResponse);
            }
        }
    }
}

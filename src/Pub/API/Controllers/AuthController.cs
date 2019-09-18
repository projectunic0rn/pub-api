using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.DTOs;
using Common.Contracts;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>  
    ///  This controller class defines the set of endpoints
    ///  available to authenticate members and complete Oauth
    ///  workflow.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
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
            catch (DbUpdateException)
            {
                errorResponse.Data = new ErrorDto(ExceptionMessage.UniquenessConstraintViolation);
                return BadRequest(errorResponse);
            }

        }
    }
}

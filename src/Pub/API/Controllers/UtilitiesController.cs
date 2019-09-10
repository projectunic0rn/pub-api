using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Contracts;
using Common.DTOs;

namespace API.Controllers
{
    [Route("api/util")]
    [AllowAnonymous]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilities _utilities;

        public UtilitiesController(IUtilities utilities)
        {
            _utilities = utilities;
        }
        
        [HttpPost("{username}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ValidationDto>))]
        public async Task<IActionResult> ValidateUsername(string username)
        {
            ResponseDto<ValidationDto> okResponse = new ResponseDto<ValidationDto>(true);

            var response = await _utilities.ValidateUsernameAsync(username);
            okResponse.Data = response; 
            
            return Ok(okResponse);
        }
    }
}
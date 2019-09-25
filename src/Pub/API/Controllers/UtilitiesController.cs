using System;
using System.Collections.Generic;
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

        [HttpGet("projecttypes")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectTypeDto>))]
        public async Task<IActionResult> GetProjectTypes()
        {
            ResponseDto<List<ProjectTypeDto>> okResponse = new ResponseDto<List<ProjectTypeDto>>(true);
            var projectTypes = await _utilities.GetProjectTypes();
            okResponse.Data = projectTypes;
            return Ok(okResponse);
        }
    }
}
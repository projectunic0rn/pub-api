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
        public IActionResult GetProjectTypes()
        {
            ResponseDto<List<ProjectTypeDto>> okResponse = new ResponseDto<List<ProjectTypeDto>>(true);
            //TODO: Update to return project types
            List<ProjectTypeDto> projectTypes = new List<ProjectTypeDto>(){
                new ProjectTypeDto { Id = Guid.NewGuid(), Type = "Healthcare"},
                new ProjectTypeDto { Id = Guid.NewGuid(), Type = "Hardware"},
                new ProjectTypeDto { Id = Guid.NewGuid(), Type = "Hardtech"},
                new ProjectTypeDto { Id = Guid.NewGuid(), Type = "Language Learning"},
            };
            
            okResponse.Data = projectTypes;

            return Ok(okResponse);
        }
    }
}
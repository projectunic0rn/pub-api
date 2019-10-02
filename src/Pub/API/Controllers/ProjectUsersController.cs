using Microsoft.AspNetCore.Mvc;
using System;
using Common.DTOs;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Domain.Exceptions;

namespace API.Controllers
{
    /// <summary>
    ///  This controller class defines the set of endpoints
    ///  available for project users 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUsersController : ControllerBase
    {
        private readonly IProjectUser _projectUser;
        
        public ProjectUsersController(IProjectUser projectUser)
        {
            _projectUser = projectUser;
        }

        // POST api/[controller]
        #if !DEBUG
        [Authorize]
        #endif
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectUserDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        public async Task<ActionResult<ProjectDto>> CreateProjectUser([FromBody] ProjectUserDto project)
        {
            ResponseDto<ProjectUserDto> okResponse = new ResponseDto<ProjectUserDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                okResponse.Data = await _projectUser.CreateProjectUserAsync(project);
            }
            catch(ProjectUserException e)
            {
                errorResponse.Data = new ErrorDto(e.Message);
                return BadRequest(errorResponse);
            }
            
            return Ok(okResponse);
        }

        // DELETE api/[controller]
        #if !DEBUG
        [Authorize]
        #endif
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectUser.DeleteProjectUserAsync(id);
            return Ok();
        }
    }
}
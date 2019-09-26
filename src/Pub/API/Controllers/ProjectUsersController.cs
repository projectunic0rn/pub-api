using Microsoft.AspNetCore.Mvc;
using System;
using Common.DTOs;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    /// <summary>
    ///  This controller class defines the set of endpoints
    ///  available for project users 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectUsersController : ControllerBase
    {
        private readonly IProjectUser _projectUser;
        
        public ProjectUsersController(IProjectUser projectUser)
        {
            _projectUser = projectUser;
        }
        
        // POST api/[controller]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectUserDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] ProjectUserDto project)
        {
            ResponseDto<ProjectUserDto> okResponse = new ResponseDto<ProjectUserDto>(true)
            {
                Data = await _projectUser.CreateProjectUserAsync(project)
            };

            return Ok(okResponse);
        }
        
        // DELETE api/[controller]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectUser.DeleteProjectUserAsync(id);
            return Ok();
        }
    }
}
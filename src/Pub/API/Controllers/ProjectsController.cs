using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Common.DTOs;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Exceptions;

namespace API.Controllers
{
    /// <summary>
    ///  This controller class defines the set of endpoints
    ///  available to handle all project related functionality
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProject _project;

        public ProjectsController(IProject project)
        {
            _project = project;
        }

        // GET api/[controller]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseDto<List<ProjectDto>>))]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            ResponseDto<List<ProjectDto>> okResponse = new ResponseDto<List<ProjectDto>>(true)
            {
                Data = await _project.GetProjectsAsync()
            };
            return Ok(okResponse);
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectDto>))]
        public async Task<ActionResult<ProjectDto>> GetProject(Guid id)
        {
            ResponseDto<ProjectDto> okResponse = new ResponseDto<ProjectDto>(true)
            {
                Data = await _project.GetProjectAsync(id)
            };
            return Ok(okResponse);
        }

        // POST api/[controller]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] ProjectDto project)
        {
            ResponseDto<ProjectDto> okResponse = new ResponseDto<ProjectDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                var createdProject = await _project.CreateProjectAsync(project);
                okResponse.Data = createdProject;
            }
            catch (ProjectException e)
            {
                errorResponse.Data = new ErrorDto(e.Message);
                return BadRequest(errorResponse);
            }

            return Ok(okResponse);
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _project.DeleteProjectAsync(id);
            return Ok();
        }
    }
}
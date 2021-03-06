using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Common.DTOs;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<IActionResult> GetProjects(bool searchableOnly = true)
        {
            ResponseDto<List<ProjectDto>> okResponse = new ResponseDto<List<ProjectDto>>(true)
            {
                Data = await _project.GetProjectsAsync(searchableOnly)
            };
            return Ok(okResponse);
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<DetailedProjectDto>))]
        public async Task<IActionResult> GetProject(Guid id)
        {
            ResponseDto<DetailedProjectDto> okResponse = new ResponseDto<DetailedProjectDto>(true)
            {
                Data = await _project.GetProjectAsync(id)
            };
            return Ok(okResponse);
        }

        // POST api/[controller]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto project)
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

        // PUT api/[controller]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ResponseDto<DetailedProjectDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> UpdateProject([FromBody] DetailedProjectDto project)
        {
            ResponseDto<DetailedProjectDto> okResponse = new ResponseDto<DetailedProjectDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                var updatedProject = await _project.UpdateProjectAsync(project);
                okResponse.Data = updatedProject;
            }
            catch (ProjectException e)
            {
                errorResponse.Data = new ErrorDto(e.Message);
                return BadRequest(errorResponse);
            }

            return Ok(okResponse);
        }

        // PATCH api/[controller]
        [HttpPatch("{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<DetailedProjectDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> PatchProject(Guid Id, [FromBody] JsonPatchDocument projectPatch)
        {
            ResponseDto<DetailedProjectDto> okResponse = new ResponseDto<DetailedProjectDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            try
            {
                var patchedProject = await _project.PatchProjectAsync(Id, projectPatch);
                okResponse.Data = patchedProject;
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
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _project.DeleteProjectAsync(id);
            return Ok();
        }
    }
}
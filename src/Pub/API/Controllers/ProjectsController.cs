using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using API.DTOs;

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
        // GET api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetProjects()
        {
            return new List<ProjectDto>()
            {
                new ProjectDto()
                {
                    Name = "Remote Hackathon",
                    Description = "A website for organizing remote hackathons",
                    LaunchDate = DateTime.Now
                },
                new ProjectDto()
                {
                    Name = "Project Unicorn",
                    Description = "A place for developers to create and collborate on projects",
                    LaunchDate = DateTime.Now
                },
                new ProjectDto()
                {
                    Name = "Mentrship",
                    Description = "Project Unicorn's first project",
                    LaunchDate = DateTime.Now
                }
            }.ToArray();
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProject(int id)
        {
            return new ProjectDto()
            {
                Name = "Remote Hackathon",
                Description = "A website for organizing remote hackathons",
                LaunchDate = DateTime.Now,
            };
        }
    }
}
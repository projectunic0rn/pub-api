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
    public class ProjectsController
    {
        public ActionResult<IEnumerable<ProjectDto>> GetProjects()
        {
            return new List<ProjectDto>()
            {
                new ProjectDto()
                {
                    Id = 1,
                    Name = "Remote Hackathon",
                    Description = "A website for organizing remote hackathons",
                    LaunchDate = DateTime.Now
                },
                new ProjectDto()
                {
                    Id = 2,
                    Name = "Project Unicorn",
                    Description = "A place for developers to create and collborate on projects",
                    LaunchDate = DateTime.Now
                },
                new ProjectDto()
                {
                    Id = 3,
                    Name = "Mentrship",
                    Description = "Project Unicorn's first project",
                    LaunchDate = DateTime.Now
                }
            }.ToArray();
        }

        [Route("{id}")]
        public ActionResult<ProjectDto> GetProject(int id)
        {
            return new ProjectDto()
            {
                Id = id,
                Name = "Remote Hackathon",
                Description = "A website for organizing remote hackathons",
                LaunchDate = DateTime.Now,
                ProjectType = 1,
                RepositoryLink = "https://github.com/projectunic0rn/remotehackathon-ui",
                InvitationLink = "https://slack.com/join/projectunic0rn/0w2iedWKF00034F"
            };
        }
    }
}
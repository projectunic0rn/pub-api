using System.Threading.Tasks;
using Xunit;
using Common.Contracts;
using API.Controllers;
using Moq;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace API.Tests.Unit
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async Task GetProjects_CallWithMockedIProject_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IProject>();

            var projects = new List<ProjectDto>(){
                new ProjectDto() { Id = Guid.NewGuid(), Name = "Project"}
            };

            mock.Setup(project => project.GetProjectsAsync(true)).ReturnsAsync(projects);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.GetProjects(true);
            var response = (OkObjectResult)result;
            var objectResult = (ResponseDto<List<ProjectDto>>)response.Value;
            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<List<ProjectDto>>>(response.Value);
        }

        [Fact]
        public async Task GetProject_CallWithMockedIProject_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.NewGuid();
            var project = new ProjectDto(){
                 Id = projectGuid, 
                 Name = "Project"
            };

            mock.Setup(project => project.GetProjectAsync(projectGuid)).ReturnsAsync(project);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.GetProject(projectGuid);
            var response = (OkObjectResult)result;
            var objectResult = (ResponseDto<ProjectDto>)response.Value;
            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ProjectDto>>(response.Value);
            Assert.Equal(objectResult.Data.Id, projectGuid);
        }
    }
}

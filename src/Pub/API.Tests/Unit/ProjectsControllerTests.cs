using System.Threading.Tasks;
using Xunit;
using Common.Contracts;
using API.Controllers;
using Moq;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Domain.Exceptions;

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

        [Fact]
        public async Task CreateProject_CallWithMockedIProject_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.Empty;
            var projectDto = new ProjectDto(){
                 Id = projectGuid,
                 Name = "Project"
            };

            mock.Setup(project => project.CreateProjectAsync(projectDto)).ReturnsAsync(projectDto);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.CreateProject(projectDto);
            var response = (OkObjectResult)result;
            var objectResult = (ResponseDto<ProjectDto>)response.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ProjectDto>>(response.Value);
        }

        [Fact]
        public async Task CreateProject_CallWithMockedIProject_ThrowsAndCatchesProjectException()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.Empty;
            var projectDto = new ProjectDto(){
                 Id = projectGuid,
                 Name = "Project"
            };

            var message = "ExceptionThrown";
            var ex = new ProjectException(message);
            mock.Setup(project => project.CreateProjectAsync(projectDto)).ThrowsAsync(ex);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.CreateProject(projectDto);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ResponseDto<ErrorDto>>(response.Value);
            Assert.Equal(message, objectResult.Data.Message);
        }

        [Fact]
        public async Task UpdateProject_CallWithMockedIProject_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.Empty;
            var projectDto = new ProjectDto(){
                 Id = projectGuid,
                 Name = "Project"
            };

            mock.Setup(project => project.UpdateProjectAsync(projectDto)).ReturnsAsync(projectDto);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.UpdateProject(projectDto);
            var response = (OkObjectResult)result;
            var objectResult = (ResponseDto<ProjectDto>)response.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ProjectDto>>(response.Value);
        }

        [Fact]
        public async Task UpdateProject_CallWithMockedIProject_ThrowsAndCatchesProjectException()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.Empty;
            var projectDto = new ProjectDto(){
                 Id = projectGuid,
                 Name = "Project"
            };

            var message = "ExceptionThrown";
            var ex = new ProjectException(message);
            mock.Setup(project => project.UpdateProjectAsync(projectDto)).ThrowsAsync(ex);
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.UpdateProject(projectDto);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ResponseDto<ErrorDto>>(response.Value);
            Assert.Equal(message, objectResult.Data.Message);
        }

        [Fact]
        public async Task DeleteProject_CallWithMockedIProject_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IProject>();
            var projectGuid = Guid.NewGuid();
            var projectDto = new ProjectDto(){
                 Id = projectGuid,
                 Name = "Project"
            };

            mock.Setup(project => project.DeleteProjectAsync(projectGuid)).Returns(Task.Delay(0));
            var projectsController = new ProjectsController(mock.Object);

            // Act
            var result = await projectsController.DeleteProject(projectGuid);
            var response = (OkResult)result;

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

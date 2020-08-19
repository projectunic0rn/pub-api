using System;
using Xunit;
using Moq;
using Common.Contracts;
using Common.DTOs;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace API.Tests.Unit
{
    public class ProjectUsersControllerTests
    {
        [Fact]
        public async Task CreateProjectUser_CallWithMockedIProjectUser_ReturnOkObjectResult() {
            // Arrange
            var mock = new Mock<IProjectUser>();
            var id = Guid.Empty;
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var projectUser = new ProjectUserDto() {
                Id = id,
                ProjectId = projectId,
                UserId = userId,
                Username = "username",
                IsOwner = true
            };
            mock.Setup(pu => pu.CreateProjectUserAsync(projectUser)).ReturnsAsync(projectUser);
            var controller = new ProjectUsersController(mock.Object);

            // Act
            var result = await controller.CreateProjectUser(projectUser);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ProjectUserDto>>(response.Value);
        }

        [Fact]
        public async Task CreateProjectUser_CallWithMockedIProjectUser_CatchesAndThrowsProjectUserException() {
            // Arrange
            var mock = new Mock<IProjectUser>();
            var id = Guid.Empty;
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var projectUser = new ProjectUserDto() {
                Id = id,
                ProjectId = projectId,
                UserId = userId,
                Username = "username",
                IsOwner = true
            };

            var message = "Exception Message";
            var ex = new ProjectUserException(message);

            mock.Setup(pu => pu.CreateProjectUserAsync(projectUser)).ThrowsAsync(ex);
            var controller = new ProjectUsersController(mock.Object);

            // Act
            var result = await controller.CreateProjectUser(projectUser);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ResponseDto<ErrorDto>>(response.Value);
            Assert.Equal(message, objectResult.Data.Message);
        }

        [Fact]
        public async Task DeleteProject_CallWithMockedIProjectUser_ReturnOkObjectResult() {
            // Arrange
            var mock = new Mock<IProjectUser>();
            var id = Guid.NewGuid();
            mock.Setup(pu => pu.DeleteProjectUserAsync(id)).Returns(Task.Delay(0));
            var controller = new ProjectUsersController(mock.Object);

            // Act
            var result = await controller.DeleteProject(id);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ProjectUserDto>>(response.Value);
        }

        [Fact]
        public async Task DeleteProject_CallWithMockedIProjectUser_CatchesAndThrowsProjectUserException() {
            // Arrange
            var mock = new Mock<IProjectUser>();
            var id = Guid.NewGuid();

            var message = "Exception Message";
            var ex = new ProjectUserException(message);

            mock.Setup(pu => pu.DeleteProjectUserAsync(id)).ThrowsAsync(ex);
            var controller = new ProjectUsersController(mock.Object);

            // Act
            var result = await controller.DeleteProject(id);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<ResponseDto<ErrorDto>>(response.Value);
            Assert.Equal(message, objectResult.Data.Message);
        }
    }
}
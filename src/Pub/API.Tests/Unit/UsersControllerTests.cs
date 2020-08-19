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
    public class UsersControllerTests
    {
        [Fact]
        public async Task CreateUser_CallWithMockedIProjectUser_ReturnOkObjectResult() {
            // Arrange
            var mock = new Mock<IUser>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var user = new UserDto() {
                Id = id,
                Username = "roy",
                Email = "roy@email.com",
            };

            mock.Setup(u => u.GetUserAsync(id)).ReturnsAsync(user);
            var controller = new UsersController(mock.Object);

            // Act
            var result = await controller.GetUser(id);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<UserDto>>(response.Value);
        }

        [Fact]
        public async Task UpdateUser_CallWithMockedIProjectUser_ReturnOkObjectResult() {
            // Arrange
            var mock = new Mock<IUser>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var user = new UserDto() {
                Id = id,
                Username = "roy",
                Email = "roy@email.com",
            };

            mock.Setup(u => u.UpdateUserAsync(user)).ReturnsAsync(user);
            var controller = new UsersController(mock.Object);

            // Act
            var result = await controller.UpdateUser(user);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<UserDto>>(response.Value);
        }
    }
}
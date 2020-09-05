using System;
using Xunit;
using Moq;
using Common.Contracts;
using Common.DTOs;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Tests.Unit
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task CreateUser_CallWithMockedIProjectUser_ReturnOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IUser>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var user = new UserDto()
            {
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
        public async Task UpdateUser_CallWithMockedIProjectUser_ReturnOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IUser>();
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var user = new UserDto()
            {
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

        [Fact]
        public async Task GetRecentDevs_CallWithMockedIProjectUser_ReturnOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IUser>();
            var recentDevs = new List<RecentDevDto>() {
                new RecentDevDto() {
                    Id = Guid.NewGuid(),
                    Bio = "hi",
                    UpdatedAt = DateTimeOffset.UtcNow,
                },
                new RecentDevDto() {
                    Id = Guid.NewGuid(),
                    Bio = "hi",
                    UpdatedAt = DateTimeOffset.UtcNow,
                }
            };

            mock.Setup(u => u.GetRecentDevsAsync()).ReturnsAsync(recentDevs);
            var controller = new UsersController(mock.Object);

            // Act
            var result = await controller.GetRecentDevs();
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<List<RecentDevDto>>>(response.Value);
        }
    }
}
using System.Threading.Tasks;
using Xunit;
using Common.Contracts;
using API.Controllers;
using Moq;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Tests.Unit
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Register_CallWithMockedIAuthentication_ReturnsOkObjectResult()
        {
            // Arrange
            var mock = new Mock<IAuthentication>();
            var registrationDto = new RegistrationDto() {
                Username = "roymoran",
                Email = "roy@email.com",
                Password = "password",
                PasswordConfirmation = "password",
                Locale = "en-US",
                Timezone = "Asia/Calcutta",
            };

            var jsonWebToken = new JsonWebTokenDto("expected_token");
            mock.Setup(auth => auth.RegisterUserAsync(registrationDto)).ReturnsAsync(jsonWebToken);
            var authController = new AuthController(mock.Object);

            // Act
            var result = await authController.Register(registrationDto);
            var response = (OkObjectResult)result;
            var objectResult = (ResponseDto<JsonWebTokenDto>)response.Value;
            // Assert
            Assert.Equal(jsonWebToken.Token, objectResult.Data.Token);
        }

        [Fact]
        public async Task Register_CallWithMockedIAuthentication_ThrowsAndCatchesAuthenticationException()
        {
            // Arrange
            var mock = new Mock<IAuthentication>();
            var registrationDto = new RegistrationDto() {
                Username = "roymoran",
                Email = "roy@email.com",
                Password = "password",
                PasswordConfirmation = "password",
                Locale = "en-US",
                Timezone = "Asia/Calcutta",
            };

            string exceptionMessage = "ExceptionThrown";
            var ex = new AuthenticationException(exceptionMessage);

            mock.Setup(auth => auth.RegisterUserAsync(registrationDto)).ThrowsAsync(ex);
            var authController = new AuthController(mock.Object);

            // Act
            var result = await authController.Register(registrationDto);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.Equal(exceptionMessage, objectResult.Data.Message);
        }

        [Fact]
        public async Task Register_CallWithMockedIAuthentication_ThrowsAndCatchesDbUpdateException()
        {
            // Arrange
            var mock = new Mock<IAuthentication>();
            var registrationDto = new RegistrationDto() {
                Username = "roymoran",
                Email = "roy@email.com",
                Password = "password",
                PasswordConfirmation = "password",
                Locale = "en-US",
                Timezone = "Asia/Calcutta",
            };

            string exceptionMessage = ExceptionMessage.UniquenessConstraintViolation;
            var ex = new DbUpdateException(exceptionMessage);

            mock.Setup(auth => auth.RegisterUserAsync(registrationDto)).ThrowsAsync(ex);
            var authController = new AuthController(mock.Object);

            // Act
            var result = await authController.Register(registrationDto);
            var response = (BadRequestObjectResult)result;
            var objectResult = (ResponseDto<ErrorDto>)response.Value;

            // Assert
            Assert.Equal(exceptionMessage, objectResult.Data.Message);
        }
    }
}

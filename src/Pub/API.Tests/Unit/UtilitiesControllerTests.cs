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
    public class UtilitiesControllerTests
    {
        [Fact]
        public async Task ValidateUsername_CallWithMockedIUtilities_ReturnOkObjectResult()
        {
            // Arrange
            var utilitiesMock = new Mock<IUtilities>();
            var notifierMock = new Mock<INotifier>();
            var username = "username";
            var usernameDto = new UsernameDto() {
                Username = username
            };
            var validationDto = new ValidationDto(true, "username valid");

            utilitiesMock.Setup(u => u.ValidateUsernameAsync(username)).ReturnsAsync(validationDto);
            var controller = new UtilitiesController(utilitiesMock.Object, notifierMock.Object);

            // Act
            var result = await controller.ValidateUsername(usernameDto);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<ValidationDto>>(response.Value);
        }

        [Fact]
        public async Task SendFeedback_CallWithMockedIUtilities_ReturnOkObjectResult()
        {
            // Arrange
            var utilitiesMock = new Mock<IUtilities>();
            var notifierMock = new Mock<INotifier>();
            var feedbackMessage = "feedback content";
            var notifcationDto = new NotificationDto(feedbackMessage);
            var feedbackDto = new FeedbackDto() {
                Content = feedbackMessage
            };
            notifierMock.Setup(n => n.SendFeedbackNotificationAsync(notifcationDto)).Returns(Task.Delay(0));
            var controller = new UtilitiesController(utilitiesMock.Object, notifierMock.Object);

            // Act
            var result = await controller.SendFeedback(feedbackDto);
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<NotificationDto>>(response.Value);
        }

        [Fact]
        public async Task GetCommunicationPlatformTypes_CallWithMockedIUtilities_ReturnOkObjectResult()
        {
            // Arrange
            var utilitiesMock = new Mock<IUtilities>();
            var notifierMock = new Mock<INotifier>();
            var communicationPlatformTypesDto = new List<CommunicationPlatformTypeDto>() {
                new CommunicationPlatformTypeDto() { Name = "slack", LogoUrl = "https://i.imgur.com/y3e8lL6.png"},
            };

            utilitiesMock.Setup(u => u.GetCommunicationPlatformTypesAsync()).ReturnsAsync(communicationPlatformTypesDto);
            var controller = new UtilitiesController(utilitiesMock.Object, notifierMock.Object);

            // Act
            var result = await controller.GetCommunicationPlatformTypes();
            var response = (OkObjectResult)result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ResponseDto<List<CommunicationPlatformTypeDto>>>(response.Value);
        }
    }
}
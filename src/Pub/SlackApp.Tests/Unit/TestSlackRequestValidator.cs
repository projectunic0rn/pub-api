using System;
using Xunit;
using SlackApp.Helpers;
using Microsoft.AspNetCore.Http;

namespace SlackApp.Tests.Unit
{
    public class TestSlackRequestValidator
    {
        [Fact]
        public void IsValid_CalledWithValidSigningSecret_ReturnsTrue()
        {
            // Arrange
            // TODO: Read signing secret from env var
            // var requestValidator = new SlackRequestValidator("signing_secret");
            // var mockRequest = new HttpRequest()
            // Act
            // var result = requestValidator.IsValid(HttpRequest request);
            // Assert
        }
    }
}

using System;
using Xunit;
using CommunicationAppDomain.ChatMessages;

namespace UnitTests
{
    public class MessagesTest
    {
        [Fact]
        public void OnboardingMessage_IsPresent_Pass()
        {
            // Arrange
            // Act
            Func<string, string, string, string> OnbordingMethod = Messages.OnboardingMessage;
            // Assert
            Assert.NotNull(OnbordingMethod);
        }

        [Fact]
        public void OnboardingMessage_ReturnsString_Pass()
        {
            // Arrange
            // Act
            string message = Messages.OnboardingMessage("testSlackId", "testId", "testPass");
            // Assert
            Assert.IsType<string>(message);
        }
    }
}
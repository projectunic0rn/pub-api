using System;
using CommunicationAppDomain.Utilities;
using Xunit;

namespace CommunicationAppDomain.Tests.Unit
{
    public class TokenHelperTests
    {
        [Fact]
        public void GenerateToken_Success_ToReturnProperLength()
        {
            // Arrange
            string generatedToken;
            // Act
            generatedToken = TokenHelper.GenerateToken();
            // Assert
            Assert.Equal(44, generatedToken.Length);
        }
    }
}

using Xunit;
using CommunicationAppDomain.Utilities;
using System.Collections.Generic;
using System;

namespace UnitTests
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
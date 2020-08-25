using API.AuthScheme;
using Common.AppSettings;
using Xunit;


namespace API.Tests.Unit
{
    public class ApiKeyAuthenticationOptionsTests
    {
        [Fact]
        public void SchemeProperty_VersionPropertyIsPresent_ReturnPass() {
            // Arrange
            var apiKeyAuthenticationOptions = new ApiKeyAuthenticationOptions();
            // Act
            var scheme = apiKeyAuthenticationOptions.Scheme;

            // Assert
            Assert.NotEmpty(scheme);
            Assert.NotNull(scheme);
            Assert.IsType<string>(scheme);
            Assert.Equal("APIKey", scheme);
        }

        public void AuthenticationTypeProperty_VersionPropertyIsPresent_ReturnPass() {
            // Arrange
            var apiKeyAuthenticationOptions = new ApiKeyAuthenticationOptions();
            // Act
            var scheme = apiKeyAuthenticationOptions.AuthenticationType;

            // Assert
            Assert.NotEmpty(scheme);
            Assert.NotNull(scheme);
            Assert.IsType<string>(scheme);
            Assert.Equal("APIKey", scheme);
        }
    }
}
using Common.AppSettings;
using Xunit;


namespace Common.Tests.Unit
{
    public class AppSettingsTests
    {
        [Fact]
        public void AppSettings_VersionPropertyIsPresent_ReturnPass() {
            // Arrange
            // Act
            var version = AppSettings.AppSettings.ApiV1;

            // Assert
            Assert.NotEmpty(version);
            Assert.NotNull(version);
            Assert.IsType<string>(version);
        }
    }
}
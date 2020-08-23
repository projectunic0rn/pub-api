using Common.AppSettings;
using Xunit;


namespace Common.Tests.Unit
{
    public class SettingsTests
    {
        [Fact]
        public void AppSettings_VersionPropertyIsPresent_ReturnPass() {
            // Arrange
            // Act
            var version = Settings.ApiV1;

            // Assert
            Assert.NotEmpty(version);
            Assert.NotNull(version);
            Assert.IsType<string>(version);
        }
    }
}
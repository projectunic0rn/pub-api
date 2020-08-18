using System;
using Xunit;
using API.ApiKeys;
using Common.POCOs;
using System.Threading.Tasks;

namespace API.Tests.Unit
{
    public class ApiKeysStoreTests
    {
        [Fact]
        public async Task Execute_FetchInternalKey_ReturnsPass()
        {
            // Arrange
            var apiKey = Guid.NewGuid().ToString();
            var apiKeyStore = new ApiKeysStore(apiKey);

            // Act
            ApiKey resultingApiKey = await apiKeyStore.Execute(apiKey);

            // Assert
            Assert.Equal("Internal", resultingApiKey.Name);
            Assert.Equal(apiKey, resultingApiKey.Key);
        }

        [Fact]
        public async Task Execute_CallExecuteWithNull_ThrowsArgumentNullException()
        {
            // Arrange
            var apiKey = Guid.NewGuid().ToString();
            var apiKeyStore = new ApiKeysStore(apiKey);

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await apiKeyStore.Execute(null));
        }
    }
}
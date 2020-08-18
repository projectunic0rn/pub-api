using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Contracts;
using Common.POCOs;

namespace API.ApiKeys
{
    public class ApiKeysStore : IFetchApiKey
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public ApiKeysStore(string internalApiKey)
        {
            var existingApiKeys = new List<ApiKey>
            {
                new ApiKey(1, "Internal", internalApiKey),
            };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            if (providedApiKey == null)
            {
                throw new ArgumentNullException(providedApiKey);
            }

            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}

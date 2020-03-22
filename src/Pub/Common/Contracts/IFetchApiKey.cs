using System;
using System.Threading.Tasks;
using Common.POCOs;

namespace Common.Contracts
{
    public interface IFetchApiKey
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}

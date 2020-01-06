using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IMessageQueue
    {
        Task SendMessageAsync<T>(T Messsage);
        Task SendMessagesAsync<T>(List<T> Messsage);
        
    }
}
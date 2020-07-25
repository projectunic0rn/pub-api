using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IMessageQueue
    {
        Task SendMessageAsync<T>(T Messsage, string label = null, DateTime? enqueueTime = null);
        Task SendMessagesAsync<T>(List<T> Messsage, string label = null, DateTime? enqueueTime = null);
    }
}
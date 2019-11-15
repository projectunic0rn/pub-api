using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface INotifier
    {
        Task<NotificationDto> SendNotificationAsync(NotificationDto notification);
    }
}
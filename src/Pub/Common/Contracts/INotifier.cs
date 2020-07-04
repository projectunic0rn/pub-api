using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface INotifier
    {
        Task SendFeedbackNotificationAsync(NotificationDto notification);
        Task SendWelcomeNotificationAsync(NotificationDto notification);
        Task SendInvalidWorkspaceInviteNotificationAsync(NotificationDto notification);
        Task SendYouJoinedProjectNotificationAsync(NotificationDto notification);
        Task SendPasswordResetNotificationAsync(NotificationDto notification);
        Task SendProjectPostedNotificationAsync(NotificationDto notification);
    }
}
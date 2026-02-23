using ClientLibrary.Models.Notifications;
using ClientLibrary.Models;

namespace ClientLibrary.Services.Contracts
{
    public interface INotificationService
    {
        event Action? OnChange;
        Task<IEnumerable<Notification>> GetMyNotificationsAsync(string userId);
        Task<IEnumerable<Notification>> GetMyUnreadNotificationsAsync(string userId);
        Task<ServiceResponse> MarkAsReadAsync(Guid id);
        Task<ServiceResponse> MarkAllsReadAsync(string userId);

        // Métodos de conveniencia para estado local si se requiere (compatibilidad)
        IReadOnlyList<Notification> Notifications { get; }
        int UnreadCount { get; }
        Task LoadInitialNotifications(string userId);
    }
}

namespace PM.WebApi.Notifications;

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}
using Microsoft.AspNetCore.SignalR;
namespace PM.WebApi.Notifications;
internal sealed class NotificationsHub : Hub<INotificationClient>
{
    public override Task OnConnectedAsync()
    {
        Clients.Client(Context.ConnectionId).ReceiveNotification($"Test {Context.User?.Identity?.Name}");
        return base.OnConnectedAsync();
    }
}
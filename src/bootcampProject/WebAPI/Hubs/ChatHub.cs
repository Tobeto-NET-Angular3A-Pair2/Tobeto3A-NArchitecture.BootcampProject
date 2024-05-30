using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class ChatHub : Hub
{
    public static Dictionary<string, Guid> UserConnections = new();

    public async Task Connect(Guid userId)
    {
        UserConnections.Add(Context.ConnectionId, userId);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        UserConnections.Remove(Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }
}

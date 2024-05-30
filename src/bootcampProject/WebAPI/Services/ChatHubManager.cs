using System;
using Application.Common.Interfaces;
using Application.Features.Messages.Commands.Create;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using NArchitecture.Core.Security.Entities;
using Nest;
using WebAPI.Hubs;

namespace WebAPI.Services;

public class ChatHubManager : IChatHubService
{
    private readonly IHubContext<ChatHub> _hubContext;

    public ChatHubManager(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task SendMessageAsync(CreatedMessageResponse response, CancellationToken cancellationToken)
    {
        var chatConnectionIds = ChatHub
            .UserConnections.Where(p => p.Value == response.SenderId || p.Value == response.ReceiverId)
            .Select(p => p.Key)
            .ToList();

        return _hubContext.Clients.Clients(chatConnectionIds).SendAsync("SendMessage", response, cancellationToken);
    }
}

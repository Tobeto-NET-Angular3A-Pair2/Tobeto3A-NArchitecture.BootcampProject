using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MessageRepository : EfRepositoryBase<Message, int, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext context)
        : base(context) { }

    public async Task<List<Message>> GetChatMessagesAsync(
        Guid senderId,
        Guid receiverId,
        CancellationToken cancellationToken = default
    )
    {
        List<Message> messages = await Query()
            .AsNoTracking()
            .Where(m =>
                (m.SenderId == senderId && m.ReceiverId == receiverId) || (m.ReceiverId == senderId && m.SenderId == receiverId)
            )
            .ToListAsync();

        return messages;
    }

    public async Task<List<Guid>> GetMessagedUserIdsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        List<Guid> messagedUserIds = await Query()
            .AsNoTracking()
            .Where(m => m.SenderId == userId || m.ReceiverId == userId)
            .Select(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
            .Distinct()
            .ToListAsync();

        return messagedUserIds;
    }
}

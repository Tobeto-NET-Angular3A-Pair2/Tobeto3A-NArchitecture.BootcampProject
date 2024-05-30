using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMessageRepository : IAsyncRepository<Message, int>, IRepository<Message, int>
{
    Task<List<Message>> GetChatMessagesAsync(Guid senderId, Guid receiverId, CancellationToken cancellationToken = default);

    Task<List<Guid>> GetMessagedUserIdsAsync(Guid userId, CancellationToken cancellationToken = default);
}

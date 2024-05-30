using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.DeleteChat;

public class DeletedChatResponse : IResponse
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public int MessageCount { get; set; }
    public DateTime DeletedDate { get; set; }
}

using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.Create;

public class CreatedMessageResponse : IResponse
{
    public int Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
}
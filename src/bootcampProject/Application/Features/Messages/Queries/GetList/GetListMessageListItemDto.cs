using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageListItemDto : IDto
{
    public int Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BootcampComments.Queries.GetList;

public class GetListBootcampCommentListItemDto : IDto
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }
}
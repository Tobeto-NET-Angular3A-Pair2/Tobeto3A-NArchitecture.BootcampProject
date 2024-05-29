using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid InstructorId { get; set; }
}

using NArchitecture.Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime CreatedDate { get; set; }
}

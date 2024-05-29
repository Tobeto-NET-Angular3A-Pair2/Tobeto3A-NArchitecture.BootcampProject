using NArchitecture.Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Update;

public class UpdatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

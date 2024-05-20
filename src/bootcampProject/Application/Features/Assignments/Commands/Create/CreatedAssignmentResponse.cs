using NArchitecture.Core.Application.Responses;

namespace Application.Features.Assignments.Commands.Create;

public class CreatedAssignmentResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }
}
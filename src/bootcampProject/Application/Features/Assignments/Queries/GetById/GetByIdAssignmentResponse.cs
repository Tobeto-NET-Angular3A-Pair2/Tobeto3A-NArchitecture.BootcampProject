using NArchitecture.Core.Application.Responses;

namespace Application.Features.Assignments.Queries.GetById;

public class GetByIdAssignmentResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }
}

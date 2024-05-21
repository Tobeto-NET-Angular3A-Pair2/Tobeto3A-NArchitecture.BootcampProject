using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Assignments.Queries.GetList;

public class GetListAssignmentListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }
}

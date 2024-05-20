using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Evaluations.Queries.GetList;

public class GetListEvaluationListItemDto : IDto
{
    public int Id { get; set; }
    public string Criteria { get; set; }
    public int LessonId { get; set; }
}
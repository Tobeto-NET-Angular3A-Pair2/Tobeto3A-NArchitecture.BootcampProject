using NArchitecture.Core.Application.Responses;

namespace Application.Features.Evaluations.Queries.GetById;

public class GetByIdEvaluationResponse : IResponse
{
    public int Id { get; set; }
    public string Criteria { get; set; }
    public int LessonId { get; set; }
}

using NArchitecture.Core.Application.Responses;

namespace Application.Features.Evaluations.Commands.Update;

public class UpdatedEvaluationResponse : IResponse
{
    public int Id { get; set; }
    public string Criteria { get; set; }
    public int LessonId { get; set; }
}

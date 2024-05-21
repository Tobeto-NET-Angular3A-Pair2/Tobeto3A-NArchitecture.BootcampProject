using NArchitecture.Core.Application.Responses;

namespace Application.Features.Evaluations.Commands.Create;

public class CreatedEvaluationResponse : IResponse
{
    public int Id { get; set; }
    public string Criteria { get; set; }
    public int LessonId { get; set; }
}

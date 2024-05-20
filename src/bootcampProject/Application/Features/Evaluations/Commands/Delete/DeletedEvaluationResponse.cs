using NArchitecture.Core.Application.Responses;

namespace Application.Features.Evaluations.Commands.Delete;

public class DeletedEvaluationResponse : IResponse
{
    public int Id { get; set; }
}
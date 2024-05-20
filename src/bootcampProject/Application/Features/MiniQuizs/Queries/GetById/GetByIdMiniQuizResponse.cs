using NArchitecture.Core.Application.Responses;

namespace Application.Features.MiniQuizs.Queries.GetById;

public class GetByIdMiniQuizResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public int LessonId { get; set; }
}
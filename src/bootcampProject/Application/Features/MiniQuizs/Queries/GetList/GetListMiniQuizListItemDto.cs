using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MiniQuizs.Queries.GetList;

public class GetListMiniQuizListItemDto : IDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public int LessonId { get; set; }
}

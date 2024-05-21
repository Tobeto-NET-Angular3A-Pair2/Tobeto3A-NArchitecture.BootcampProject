using NArchitecture.Core.Application.Dtos;

namespace Application.Features.LessonVideos.Queries.GetList;

public class GetListLessonVideoListItemDto : IDto
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int LessonId { get; set; }
}

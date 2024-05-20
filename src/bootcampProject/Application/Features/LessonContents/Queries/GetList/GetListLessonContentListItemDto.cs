using NArchitecture.Core.Application.Dtos;

namespace Application.Features.LessonContents.Queries.GetList;

public class GetListLessonContentListItemDto : IDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int LessonId { get; set; }
}
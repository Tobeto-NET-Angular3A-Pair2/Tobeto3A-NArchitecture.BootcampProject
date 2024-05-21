using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonVideos.Queries.GetById;

public class GetByIdLessonVideoResponse : IResponse
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int LessonId { get; set; }
}

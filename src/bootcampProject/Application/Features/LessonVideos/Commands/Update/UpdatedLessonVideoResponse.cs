using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonVideos.Commands.Update;

public class UpdatedLessonVideoResponse : IResponse
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int LessonId { get; set; }
}
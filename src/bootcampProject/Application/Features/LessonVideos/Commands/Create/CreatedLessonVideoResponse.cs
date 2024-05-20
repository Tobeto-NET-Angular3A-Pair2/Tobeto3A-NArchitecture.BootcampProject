using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonVideos.Commands.Create;

public class CreatedLessonVideoResponse : IResponse
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int LessonId { get; set; }
}
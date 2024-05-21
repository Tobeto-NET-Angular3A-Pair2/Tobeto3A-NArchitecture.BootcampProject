using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonVideos.Commands.Delete;

public class DeletedLessonVideoResponse : IResponse
{
    public int Id { get; set; }
}

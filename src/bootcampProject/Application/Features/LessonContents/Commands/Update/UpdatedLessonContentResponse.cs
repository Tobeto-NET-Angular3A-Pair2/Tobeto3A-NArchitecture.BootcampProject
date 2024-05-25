using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonContents.Commands.Update;

public class UpdatedLessonContentResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string VideoUrl { get; set; }
    public int LessonId { get; set; }
}

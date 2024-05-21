using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonContents.Commands.Create;

public class CreatedLessonContentResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int LessonId { get; set; }
}

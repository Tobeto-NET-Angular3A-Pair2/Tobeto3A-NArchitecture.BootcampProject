using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonContents.Commands.Delete;

public class DeletedLessonContentResponse : IResponse
{
    public int Id { get; set; }
}
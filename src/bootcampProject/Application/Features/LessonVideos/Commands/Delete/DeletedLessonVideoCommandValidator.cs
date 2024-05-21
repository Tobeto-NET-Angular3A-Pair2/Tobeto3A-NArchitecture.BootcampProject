using FluentValidation;

namespace Application.Features.LessonVideos.Commands.Delete;

public class DeleteLessonVideoCommandValidator : AbstractValidator<DeleteLessonVideoCommand>
{
    public DeleteLessonVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

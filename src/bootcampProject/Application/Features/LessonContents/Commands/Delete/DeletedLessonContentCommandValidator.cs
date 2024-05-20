using FluentValidation;

namespace Application.Features.LessonContents.Commands.Delete;

public class DeleteLessonContentCommandValidator : AbstractValidator<DeleteLessonContentCommand>
{
    public DeleteLessonContentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
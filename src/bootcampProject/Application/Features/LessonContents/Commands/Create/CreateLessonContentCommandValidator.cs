using FluentValidation;

namespace Application.Features.LessonContents.Commands.Create;

public class CreateLessonContentCommandValidator : AbstractValidator<CreateLessonContentCommand>
{
    public CreateLessonContentCommandValidator()
    {
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.LessonContents.Commands.Update;

public class UpdateLessonContentCommandValidator : AbstractValidator<UpdateLessonContentCommand>
{
    public UpdateLessonContentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}

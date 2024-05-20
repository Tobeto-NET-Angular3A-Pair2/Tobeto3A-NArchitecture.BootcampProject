using FluentValidation;

namespace Application.Features.LessonVideos.Commands.Create;

public class CreateLessonVideoCommandValidator : AbstractValidator<CreateLessonVideoCommand>
{
    public CreateLessonVideoCommandValidator()
    {
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.LessonVideos.Commands.Update;

public class UpdateLessonVideoCommandValidator : AbstractValidator<UpdateLessonVideoCommand>
{
    public UpdateLessonVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}
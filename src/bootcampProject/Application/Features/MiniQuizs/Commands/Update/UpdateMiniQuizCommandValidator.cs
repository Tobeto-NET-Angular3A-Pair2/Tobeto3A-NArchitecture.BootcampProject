using FluentValidation;

namespace Application.Features.MiniQuizs.Commands.Update;

public class UpdateMiniQuizCommandValidator : AbstractValidator<UpdateMiniQuizCommand>
{
    public UpdateMiniQuizCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.CorrectAnswer).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}

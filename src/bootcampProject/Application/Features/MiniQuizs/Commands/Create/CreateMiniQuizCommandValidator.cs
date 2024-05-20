using FluentValidation;

namespace Application.Features.MiniQuizs.Commands.Create;

public class CreateMiniQuizCommandValidator : AbstractValidator<CreateMiniQuizCommand>
{
    public CreateMiniQuizCommandValidator()
    {
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.CorrectAnswer).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}
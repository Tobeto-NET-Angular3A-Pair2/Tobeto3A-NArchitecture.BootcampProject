using FluentValidation;

namespace Application.Features.Evaluations.Commands.Create;

public class CreateEvaluationCommandValidator : AbstractValidator<CreateEvaluationCommand>
{
    public CreateEvaluationCommandValidator()
    {
        RuleFor(c => c.Criteria).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}

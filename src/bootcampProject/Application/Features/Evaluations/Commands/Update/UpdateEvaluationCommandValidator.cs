using FluentValidation;

namespace Application.Features.Evaluations.Commands.Update;

public class UpdateEvaluationCommandValidator : AbstractValidator<UpdateEvaluationCommand>
{
    public UpdateEvaluationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Criteria).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}

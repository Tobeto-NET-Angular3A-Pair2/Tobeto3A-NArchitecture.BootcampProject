using FluentValidation;

namespace Application.Features.Evaluations.Commands.Delete;

public class DeleteEvaluationCommandValidator : AbstractValidator<DeleteEvaluationCommand>
{
    public DeleteEvaluationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
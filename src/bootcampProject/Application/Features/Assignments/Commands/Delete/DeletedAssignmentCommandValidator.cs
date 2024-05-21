using FluentValidation;

namespace Application.Features.Assignments.Commands.Delete;

public class DeleteAssignmentCommandValidator : AbstractValidator<DeleteAssignmentCommand>
{
    public DeleteAssignmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

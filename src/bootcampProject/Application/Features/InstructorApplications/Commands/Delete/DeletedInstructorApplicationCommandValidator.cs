using FluentValidation;

namespace Application.Features.InstructorApplications.Commands.Delete;

public class DeleteInstructorApplicationCommandValidator : AbstractValidator<DeleteInstructorApplicationCommand>
{
    public DeleteInstructorApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

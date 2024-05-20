using FluentValidation;

namespace Application.Features.Assignments.Commands.Create;

public class CreateAssignmentCommandValidator : AbstractValidator<CreateAssignmentCommand>
{
    public CreateAssignmentCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Deadline).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}
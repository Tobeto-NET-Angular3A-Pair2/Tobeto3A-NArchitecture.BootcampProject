using FluentValidation;

namespace Application.Features.Assignments.Commands.Update;

public class UpdateAssignmentCommandValidator : AbstractValidator<UpdateAssignmentCommand>
{
    public UpdateAssignmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Deadline).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}

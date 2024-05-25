using FluentValidation;

namespace Application.Features.BootcampComments.Commands.Create;

public class CreateBootcampCommentCommandValidator : AbstractValidator<CreateBootcampCommentCommand>
{
    public CreateBootcampCommentCommandValidator()
    {
        RuleFor(c => c.Context).NotEmpty().MaximumLength(250);
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
    }
}

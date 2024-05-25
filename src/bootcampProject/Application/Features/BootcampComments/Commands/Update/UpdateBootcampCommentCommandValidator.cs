using FluentValidation;

namespace Application.Features.BootcampComments.Commands.Update;

public class UpdateBootcampCommentCommandValidator : AbstractValidator<UpdateBootcampCommentCommand>
{
    public UpdateBootcampCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Context).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
    }
}
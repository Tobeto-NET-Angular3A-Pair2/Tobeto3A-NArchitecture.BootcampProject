using FluentValidation;

namespace Application.Features.BootcampComments.Commands.Delete;

public class DeleteBootcampCommentCommandValidator : AbstractValidator<DeleteBootcampCommentCommand>
{
    public DeleteBootcampCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
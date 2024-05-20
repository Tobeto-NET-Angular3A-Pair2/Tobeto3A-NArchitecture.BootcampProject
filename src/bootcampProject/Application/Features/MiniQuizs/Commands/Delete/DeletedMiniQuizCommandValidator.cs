using FluentValidation;

namespace Application.Features.MiniQuizs.Commands.Delete;

public class DeleteMiniQuizCommandValidator : AbstractValidator<DeleteMiniQuizCommand>
{
    public DeleteMiniQuizCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
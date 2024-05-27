using FluentValidation;


namespace Application.Features.Messages.Commands.DeleteChat;
public class DeletedChatCommandValidator: AbstractValidator<DeleteChatCommand>
{
    public DeletedChatCommandValidator()
    {
        RuleFor(c => c.SenderId).NotEmpty();
        RuleFor(c => c.ReceiverId).NotEmpty();
    }
}

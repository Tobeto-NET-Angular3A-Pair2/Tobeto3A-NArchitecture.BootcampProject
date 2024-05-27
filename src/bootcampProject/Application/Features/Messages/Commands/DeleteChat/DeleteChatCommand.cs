using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Commands.DeleteChat;
public class DeleteChatCommand : IRequest<DeletedChatResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }

    public string[] Roles => [Admin, Write, MessagesOperationClaims.Delete];

    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, DeletedChatResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public DeleteChatCommandHandler(IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules, UserBusinessRules userBusinessRules)
        {
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<DeletedChatResponse> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserIdShouldBeExistsWhenSelected(request.SenderId);
            await _userBusinessRules.UserIdShouldBeExistsWhenSelected(request.ReceiverId);

            List<Message>? messages = await _messageRepository
                .GetChatMessagesAsync(request.SenderId, request.ReceiverId, cancellationToken);

            await _messageBusinessRules.ChatShouldContainsMessageWhenSelected(messages);

            int messageCount = messages.Count;

            await _messageRepository.DeleteRangeAsync(messages!, permanent: true);

            DeletedChatResponse response = new DeletedChatResponse
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                DeletedDate = DateTime.UtcNow,
                MessageCount = messageCount
            };

            return response;
        }
    }
}

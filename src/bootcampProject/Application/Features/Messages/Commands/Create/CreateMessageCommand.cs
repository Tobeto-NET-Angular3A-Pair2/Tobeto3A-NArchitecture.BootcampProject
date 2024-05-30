using Application.Common.Interfaces;
using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }

    public string[] Roles => [Admin, Write, MessagesOperationClaims.Create];

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;
        private readonly IChatHubService _chatHubService;

        public CreateMessageCommandHandler(
            IMapper mapper,
            IMessageRepository messageRepository,
            MessageBusinessRules messageBusinessRules,
            IChatHubService chatHubService
        )
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
            _chatHubService = chatHubService;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message message = _mapper.Map<Message>(request);
            message.IsRead = false;

            var createdMessage = await _messageRepository.AddAsync(message);

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(createdMessage);

            await _chatHubService.SendMessageAsync(response, cancellationToken);

            return response;
        }
    }
}

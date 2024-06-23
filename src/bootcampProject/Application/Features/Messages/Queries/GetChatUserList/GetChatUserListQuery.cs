using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Queries.GetChatUserList;

public class GetChatUserListQuery : IRequest<GetListResponse<GetChatUserListItemDto>>, ISecuredRequest
{
    public Guid UserId { get; set; }

    //public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetChatUserListQueryHandler : IRequestHandler<GetChatUserListQuery, GetListResponse<GetChatUserListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetChatUserListQueryHandler(IMessageRepository messageRepository, IUserRepository userRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetChatUserListItemDto>> Handle(
            GetChatUserListQuery request,
            CancellationToken cancellationToken
        )
        {
            var messagedUserIds = await _messageRepository.GetMessagedUserIdsAsync(request.UserId, cancellationToken);

            var messagedUsers = await _userRepository.GetListAsync(
                predicate: u => messagedUserIds.Contains(u.Id),
                index: 0,
                size: messagedUserIds.Count,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetChatUserListItemDto> response = _mapper.Map<GetListResponse<GetChatUserListItemDto>>(
                messagedUsers
            );

            return response;
        }
    }
}

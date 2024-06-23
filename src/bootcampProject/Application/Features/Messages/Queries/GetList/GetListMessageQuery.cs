using System.Linq.Expressions;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageQuery : IRequest<GetListResponse<GetListMessageListItemDto>>, ISecuredRequest
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(
            GetListMessageQuery request,
            CancellationToken cancellationToken
        )
        {
            // Predicate tan�mlamas� (Filtreleme)
            Expression<Func<Message, bool>> predicate = p =>
                (p.SenderId == request.SenderId && p.ReceiverId == request.ReceiverId)
                || (p.ReceiverId == request.SenderId && p.SenderId == request.ReceiverId);

            // OrderBy tan�mlamas� (S�ralama)
            Func<IQueryable<Message>, IOrderedQueryable<Message>> orderBy = q => q.OrderByDescending(p => p.CreatedDate);

            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                predicate: predicate,
                orderBy: orderBy,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMessageListItemDto> response = _mapper.Map<GetListResponse<GetListMessageListItemDto>>(
                messages
            );
            return response;
        }
    }
}

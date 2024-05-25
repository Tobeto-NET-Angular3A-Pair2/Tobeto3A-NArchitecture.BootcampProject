using Application.Features.BootcampComments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BootcampComments.Constants.BootcampCommentsOperationClaims;

namespace Application.Features.BootcampComments.Queries.GetList;

public class GetListBootcampCommentQuery : IRequest<GetListResponse<GetListBootcampCommentListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListBootcampCommentQueryHandler : IRequestHandler<GetListBootcampCommentQuery, GetListResponse<GetListBootcampCommentListItemDto>>
    {
        private readonly IBootcampCommentRepository _bootcampCommentRepository;
        private readonly IMapper _mapper;

        public GetListBootcampCommentQueryHandler(IBootcampCommentRepository bootcampCommentRepository, IMapper mapper)
        {
            _bootcampCommentRepository = bootcampCommentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampCommentListItemDto>> Handle(GetListBootcampCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BootcampComment> bootcampComments = await _bootcampCommentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBootcampCommentListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampCommentListItemDto>>(bootcampComments);
            return response;
        }
    }
}
using Application.Features.MiniQuizs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MiniQuizs.Constants.MiniQuizsOperationClaims;

namespace Application.Features.MiniQuizs.Queries.GetList;

public class GetListMiniQuizQuery : IRequest<GetListResponse<GetListMiniQuizListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMiniQuizs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMiniQuizs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMiniQuizQueryHandler : IRequestHandler<GetListMiniQuizQuery, GetListResponse<GetListMiniQuizListItemDto>>
    {
        private readonly IMiniQuizRepository _miniQuizRepository;
        private readonly IMapper _mapper;

        public GetListMiniQuizQueryHandler(IMiniQuizRepository miniQuizRepository, IMapper mapper)
        {
            _miniQuizRepository = miniQuizRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMiniQuizListItemDto>> Handle(GetListMiniQuizQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MiniQuiz> miniQuizs = await _miniQuizRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMiniQuizListItemDto> response = _mapper.Map<GetListResponse<GetListMiniQuizListItemDto>>(miniQuizs);
            return response;
        }
    }
}
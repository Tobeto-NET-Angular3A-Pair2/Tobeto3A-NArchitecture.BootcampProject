using Application.Features.Evaluations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Evaluations.Constants.EvaluationsOperationClaims;

namespace Application.Features.Evaluations.Queries.GetList;

public class GetListEvaluationQuery : IRequest<GetListResponse<GetListEvaluationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListEvaluations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetEvaluations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEvaluationQueryHandler
        : IRequestHandler<GetListEvaluationQuery, GetListResponse<GetListEvaluationListItemDto>>
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IMapper _mapper;

        public GetListEvaluationQueryHandler(IEvaluationRepository evaluationRepository, IMapper mapper)
        {
            _evaluationRepository = evaluationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEvaluationListItemDto>> Handle(
            GetListEvaluationQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Evaluation> evaluations = await _evaluationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEvaluationListItemDto> response = _mapper.Map<GetListResponse<GetListEvaluationListItemDto>>(
                evaluations
            );
            return response;
        }
    }
}

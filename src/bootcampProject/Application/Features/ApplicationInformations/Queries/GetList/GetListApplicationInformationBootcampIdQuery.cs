using Application.Features.ApplicationInformations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationBootcampIdQuery
    : IRequest<GetListResponse<GetListApplicationInformationListBootcampIdItemDto>>,
        ISecuredRequest
        
{
    public PageRequest PageRequest { get; set; }

    public int BootcampId { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicationInformationBootcampId({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicationInformations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationInformationBootcampIdQueryHandler
        : IRequestHandler<GetListApplicationInformationBootcampIdQuery,GetListResponse<GetListApplicationInformationListBootcampIdItemDto>>
    {
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationInformationBootcampIdQueryHandler(
            IApplicationInformationRepository applicationInformationRepository,
            IMapper mapper
        )
        {
            _applicationInformationRepository = applicationInformationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationInformationListBootcampIdItemDto>> Handle(
            GetListApplicationInformationBootcampIdQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<ApplicationInformation> applicationInformations = await _applicationInformationRepository.GetListAsync(
                predicate: b => b.BootcampId == request.BootcampId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationInformationListBootcampIdItemDto> response = _mapper.Map<
                GetListResponse<GetListApplicationInformationListBootcampIdItemDto>
            >(applicationInformations);
            return response;
        }
    }
}

using Application.Features.Assignments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Assignments.Constants.AssignmentsOperationClaims;

namespace Application.Features.Assignments.Queries.GetList;

public class GetListAssignmentQuery : IRequest<GetListResponse<GetListAssignmentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAssignments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAssignments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAssignmentQueryHandler
        : IRequestHandler<GetListAssignmentQuery, GetListResponse<GetListAssignmentListItemDto>>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public GetListAssignmentQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAssignmentListItemDto>> Handle(
            GetListAssignmentQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Assignment> assignments = await _assignmentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAssignmentListItemDto> response = _mapper.Map<GetListResponse<GetListAssignmentListItemDto>>(
                assignments
            );
            return response;
        }
    }
}

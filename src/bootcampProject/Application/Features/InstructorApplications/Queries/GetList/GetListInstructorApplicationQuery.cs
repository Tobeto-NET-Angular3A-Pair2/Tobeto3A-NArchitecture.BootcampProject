using Application.Features.InstructorApplications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.InstructorApplications.Constants.InstructorApplicationsOperationClaims;

namespace Application.Features.InstructorApplications.Queries.GetList;

public class GetListInstructorApplicationQuery : IRequest<GetListResponse<GetListInstructorApplicationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListInstructorApplicationQueryHandler : IRequestHandler<GetListInstructorApplicationQuery, GetListResponse<GetListInstructorApplicationListItemDto>>
    {
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly IMapper _mapper;

        public GetListInstructorApplicationQueryHandler(IInstructorApplicationRepository instructorApplicationRepository, IMapper mapper)
        {
            _instructorApplicationRepository = instructorApplicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInstructorApplicationListItemDto>> Handle(GetListInstructorApplicationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<InstructorApplication> instructorApplications = await _instructorApplicationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInstructorApplicationListItemDto> response = _mapper.Map<GetListResponse<GetListInstructorApplicationListItemDto>>(instructorApplications);
            return response;
        }
    }
}
using Application.Features.InstructorApplications.Constants;
using Application.Features.InstructorApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.InstructorApplications.Constants.InstructorApplicationsOperationClaims;

namespace Application.Features.InstructorApplications.Queries.GetById;

public class GetByIdInstructorApplicationQuery : IRequest<GetByIdInstructorApplicationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdInstructorApplicationQueryHandler : IRequestHandler<GetByIdInstructorApplicationQuery, GetByIdInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public GetByIdInstructorApplicationQueryHandler(IMapper mapper, IInstructorApplicationRepository instructorApplicationRepository, InstructorApplicationBusinessRules instructorApplicationBusinessRules)
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<GetByIdInstructorApplicationResponse> Handle(GetByIdInstructorApplicationQuery request, CancellationToken cancellationToken)
        {
            InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(predicate: ia => ia.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorApplicationBusinessRules.InstructorApplicationShouldExistWhenSelected(instructorApplication);

            GetByIdInstructorApplicationResponse response = _mapper.Map<GetByIdInstructorApplicationResponse>(instructorApplication);
            return response;
        }
    }
}
using Application.Features.Assignments.Constants;
using Application.Features.Assignments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Assignments.Constants.AssignmentsOperationClaims;

namespace Application.Features.Assignments.Queries.GetById;

public class GetByIdAssignmentQuery : IRequest<GetByIdAssignmentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAssignmentQueryHandler : IRequestHandler<GetByIdAssignmentQuery, GetByIdAssignmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly AssignmentBusinessRules _assignmentBusinessRules;

        public GetByIdAssignmentQueryHandler(IMapper mapper, IAssignmentRepository assignmentRepository, AssignmentBusinessRules assignmentBusinessRules)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<GetByIdAssignmentResponse> Handle(GetByIdAssignmentQuery request, CancellationToken cancellationToken)
        {
            Assignment? assignment = await _assignmentRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _assignmentBusinessRules.AssignmentShouldExistWhenSelected(assignment);

            GetByIdAssignmentResponse response = _mapper.Map<GetByIdAssignmentResponse>(assignment);
            return response;
        }
    }
}
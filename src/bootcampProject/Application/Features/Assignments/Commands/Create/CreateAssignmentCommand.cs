using Application.Features.Assignments.Constants;
using Application.Features.Assignments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Assignments.Constants.AssignmentsOperationClaims;

namespace Application.Features.Assignments.Commands.Create;

public class CreateAssignmentCommand : IRequest<CreatedAssignmentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, AssignmentsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAssignments"];

    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, CreatedAssignmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly AssignmentBusinessRules _assignmentBusinessRules;

        public CreateAssignmentCommandHandler(IMapper mapper, IAssignmentRepository assignmentRepository,
                                         AssignmentBusinessRules assignmentBusinessRules)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<CreatedAssignmentResponse> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            Assignment assignment = _mapper.Map<Assignment>(request);

            await _assignmentRepository.AddAsync(assignment);

            CreatedAssignmentResponse response = _mapper.Map<CreatedAssignmentResponse>(assignment);
            return response;
        }
    }
}
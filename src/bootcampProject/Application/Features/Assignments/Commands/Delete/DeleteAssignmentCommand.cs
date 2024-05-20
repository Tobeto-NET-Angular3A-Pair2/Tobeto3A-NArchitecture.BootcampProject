using Application.Features.Assignments.Constants;
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

namespace Application.Features.Assignments.Commands.Delete;

public class DeleteAssignmentCommand : IRequest<DeletedAssignmentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, AssignmentsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAssignments"];

    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, DeletedAssignmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly AssignmentBusinessRules _assignmentBusinessRules;

        public DeleteAssignmentCommandHandler(IMapper mapper, IAssignmentRepository assignmentRepository,
                                         AssignmentBusinessRules assignmentBusinessRules)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<DeletedAssignmentResponse> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            Assignment? assignment = await _assignmentRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _assignmentBusinessRules.AssignmentShouldExistWhenSelected(assignment);

            await _assignmentRepository.DeleteAsync(assignment!);

            DeletedAssignmentResponse response = _mapper.Map<DeletedAssignmentResponse>(assignment);
            return response;
        }
    }
}
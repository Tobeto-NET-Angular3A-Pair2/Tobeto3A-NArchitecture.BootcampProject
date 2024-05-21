using Application.Features.Assignments.Constants;
using Application.Features.Assignments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Assignments.Constants.AssignmentsOperationClaims;

namespace Application.Features.Assignments.Commands.Update;

public class UpdateAssignmentCommand
    : IRequest<UpdatedAssignmentResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, AssignmentsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAssignments"];

    public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, UpdatedAssignmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly AssignmentBusinessRules _assignmentBusinessRules;

        public UpdateAssignmentCommandHandler(
            IMapper mapper,
            IAssignmentRepository assignmentRepository,
            AssignmentBusinessRules assignmentBusinessRules
        )
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        public async Task<UpdatedAssignmentResponse> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            Assignment? assignment = await _assignmentRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _assignmentBusinessRules.AssignmentShouldExistWhenSelected(assignment);
            assignment = _mapper.Map(request, assignment);

            await _assignmentRepository.UpdateAsync(assignment!);

            UpdatedAssignmentResponse response = _mapper.Map<UpdatedAssignmentResponse>(assignment);
            return response;
        }
    }
}

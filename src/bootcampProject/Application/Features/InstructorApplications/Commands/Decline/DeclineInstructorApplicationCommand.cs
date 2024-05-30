using Application.Features.InstructorApplications.Commands.Approve;
using Application.Features.InstructorApplications.Constants;
using Application.Features.InstructorApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.InstructorApplications.Constants.InstructorApplicationsOperationClaims;

namespace Application.Features.InstructorApplications.Commands.Decline;

public class DeclineInstructorApplicationCommand
    : IRequest<DeclinedInstructorApplicationResponse>,
        ISecuredRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public string[] Roles => [Admin, Write, InstructorApplicationsOperationClaims.Update];

    private readonly IMapper _mapper;
    private readonly IInstructorApplicationRepository _instructorApplicationRepository;
    private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

    public class DeclineInstructorApplicationCommandHandler
        : IRequestHandler<DeclineInstructorApplicationCommand, DeclinedInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public DeclineInstructorApplicationCommandHandler(
            IMapper mapper,
            IInstructorApplicationRepository instructorApplicationRepository,
            InstructorApplicationBusinessRules instructorApplicationBusinessRules
        )
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<DeclinedInstructorApplicationResponse> Handle(
            DeclineInstructorApplicationCommand request,
            CancellationToken cancellationToken
        )
        {
            InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(
                predicate: ia => ia.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _instructorApplicationBusinessRules.InstructorApplicationShouldExistWhenSelected(instructorApplication);

            instructorApplication.IsApproved = false;

            await _instructorApplicationRepository.UpdateAsync(instructorApplication!);

            DeclinedInstructorApplicationResponse response = _mapper.Map<DeclinedInstructorApplicationResponse>(
                instructorApplication
            );
            return response;
        }
    }
}

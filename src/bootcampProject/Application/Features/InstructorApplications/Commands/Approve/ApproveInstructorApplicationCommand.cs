using Application.Features.InstructorApplications.Commands.Update;
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

namespace Application.Features.InstructorApplications.Commands.Approve;
public class ApproveInstructorApplicationCommand : IRequest<ApprovedInstructorApplicationResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string? Comment { get; set; }

    public string[] Roles => [Admin, Write, InstructorApplicationsOperationClaims.Update];

    public class ApproveInstructorApplicationCommandHandler : IRequestHandler<ApproveInstructorApplicationCommand, ApprovedInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public ApproveInstructorApplicationCommandHandler(IMapper mapper, IInstructorApplicationRepository instructorApplicationRepository,
                                         InstructorApplicationBusinessRules instructorApplicationBusinessRules)
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<ApprovedInstructorApplicationResponse> Handle(ApproveInstructorApplicationCommand request, CancellationToken cancellationToken)
        {
            InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(predicate: ia => ia.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorApplicationBusinessRules.InstructorApplicationShouldExistWhenSelected(instructorApplication);

            instructorApplication.IsApproved = true;

            await _instructorApplicationRepository.UpdateAsync(instructorApplication!);

            ApprovedInstructorApplicationResponse response = _mapper.Map<ApprovedInstructorApplicationResponse>(instructorApplication);
            return response;
        }
    }
}


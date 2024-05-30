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

namespace Application.Features.InstructorApplications.Commands.Update;

public class UpdateInstructorApplicationCommand
    : IRequest<UpdatedInstructorApplicationResponse>,
        ISecuredRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? NationalIdentity { get; set; }
    public string? CompanyName { get; set; }
    public string? AdditionalInformation { get; set; }
    public string? Comment { get; set; }
    public bool? IsApproved { get; set; }

    public string[] Roles => [Admin, Write, InstructorApplicationsOperationClaims.Update];

    public class UpdateInstructorApplicationCommandHandler
        : IRequestHandler<UpdateInstructorApplicationCommand, UpdatedInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public UpdateInstructorApplicationCommandHandler(
            IMapper mapper,
            IInstructorApplicationRepository instructorApplicationRepository,
            InstructorApplicationBusinessRules instructorApplicationBusinessRules
        )
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<UpdatedInstructorApplicationResponse> Handle(
            UpdateInstructorApplicationCommand request,
            CancellationToken cancellationToken
        )
        {
            InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(
                predicate: ia => ia.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _instructorApplicationBusinessRules.InstructorApplicationShouldExistWhenSelected(instructorApplication);
            instructorApplication = _mapper.Map(request, instructorApplication);

            await _instructorApplicationRepository.UpdateAsync(instructorApplication!);

            UpdatedInstructorApplicationResponse response = _mapper.Map<UpdatedInstructorApplicationResponse>(
                instructorApplication
            );
            return response;
        }
    }
}

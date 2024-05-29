using Application.Features.InstructorApplications.Constants;
using Application.Features.InstructorApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.InstructorApplications.Constants.InstructorApplicationsOperationClaims;

namespace Application.Features.InstructorApplications.Commands.Create;

public class CreateInstructorApplicationCommand : IRequest<CreatedInstructorApplicationResponse>, ILoggableRequest, ITransactionalRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? NationalIdentity { get; set; }
    public string? CompanyName { get; set; }
    public string? AdditionalInformation { get; set; }
    public bool? IsApproved { get; set; }


    public class CreateInstructorApplicationCommandHandler : IRequestHandler<CreateInstructorApplicationCommand, CreatedInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public CreateInstructorApplicationCommandHandler(IMapper mapper, IInstructorApplicationRepository instructorApplicationRepository,
                                         InstructorApplicationBusinessRules instructorApplicationBusinessRules)
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<CreatedInstructorApplicationResponse> Handle(CreateInstructorApplicationCommand request, CancellationToken cancellationToken)
        {
            await _instructorApplicationBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);

            await _instructorApplicationBusinessRules.InstructorApplicationEmailShouldNotExistsWhenInsert(request.Email);

            InstructorApplication instructorApplication = _mapper.Map<InstructorApplication>(request);

            await _instructorApplicationRepository.AddAsync(instructorApplication);

            CreatedInstructorApplicationResponse response = _mapper.Map<CreatedInstructorApplicationResponse>(instructorApplication);
            return response;
        }
    }
}
using Application.Features.InstructorApplications.Constants;
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

namespace Application.Features.InstructorApplications.Commands.Delete;

public class DeleteInstructorApplicationCommand : IRequest<DeletedInstructorApplicationResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, InstructorApplicationsOperationClaims.Delete];

    public class DeleteInstructorApplicationCommandHandler : IRequestHandler<DeleteInstructorApplicationCommand, DeletedInstructorApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorApplicationRepository _instructorApplicationRepository;
        private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

        public DeleteInstructorApplicationCommandHandler(IMapper mapper, IInstructorApplicationRepository instructorApplicationRepository,
                                         InstructorApplicationBusinessRules instructorApplicationBusinessRules)
        {
            _mapper = mapper;
            _instructorApplicationRepository = instructorApplicationRepository;
            _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
        }

        public async Task<DeletedInstructorApplicationResponse> Handle(DeleteInstructorApplicationCommand request, CancellationToken cancellationToken)
        {
            InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(predicate: ia => ia.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorApplicationBusinessRules.InstructorApplicationShouldExistWhenSelected(instructorApplication);

            await _instructorApplicationRepository.DeleteAsync(instructorApplication!);

            DeletedInstructorApplicationResponse response = _mapper.Map<DeletedInstructorApplicationResponse>(instructorApplication);
            return response;
        }
    }
}
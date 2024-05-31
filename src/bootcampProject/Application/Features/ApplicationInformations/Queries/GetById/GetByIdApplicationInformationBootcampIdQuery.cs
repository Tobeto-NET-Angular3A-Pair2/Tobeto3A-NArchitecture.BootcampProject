using Application.Features.Applicants.Constants;
using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Queries.GetById;

public class GetByIdApplicationInformationBootcampIdQuery : IRequest<GetByIdApplicationInformationResponse>, ISecuredRequest
{
    public int BootcampId { get; set; }

    public string[] Roles => [
        ApplicationInformationsOperationClaims.Admin,
        ApplicantsOperationClaims.Admin];

    public class GetByIdApplicationInformationBootcampIdQueryHandler
        : IRequestHandler<GetByIdApplicationInformationBootcampIdQuery, GetByIdApplicationInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

        public GetByIdApplicationInformationBootcampIdQueryHandler(
            IMapper mapper,
            IApplicationInformationRepository applicationInformationRepository,
            ApplicationInformationBusinessRules applicationInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
            _applicationInformationBusinessRules = applicationInformationBusinessRules;
        }

        public async Task<GetByIdApplicationInformationResponse> Handle(
            GetByIdApplicationInformationBootcampIdQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
                predicate: ai => ai.BootcampId == request.BootcampId,
                cancellationToken: cancellationToken
            );
            await _applicationInformationBusinessRules.ApplicationInformationShouldExistWhenSelected(applicationInformation);

            GetByIdApplicationInformationResponse response = _mapper.Map<GetByIdApplicationInformationResponse>(
                applicationInformation
            );
            return response;
        }
    }
}

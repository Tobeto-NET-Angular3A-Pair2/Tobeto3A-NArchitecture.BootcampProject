using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;
using Application.Features.Instructors.Constants;

namespace Application.Features.Bootcamps.Commands.Create;

public class CreateBootcampCommand : IRequest<CreatedBootcampResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Boolean BootcampState { get; set; }
    public string BootcampImage {  get; set; }

    public string[] Roles => new[]
           {
            BootcampsOperationClaims.Admin,
            BootcampsOperationClaims.Write,
            BootcampsOperationClaims.Create,
            InstructorsOperationClaims.Admin
        };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class CreateBootcampCommandHandler : IRequestHandler<CreateBootcampCommand, CreatedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;

        public CreateBootcampCommandHandler(IMapper mapper, IBootcampRepository bootcampRepository,
                                         BootcampBusinessRules bootcampBusinessRules)
        {
            _mapper = mapper;
            _bootcampRepository = bootcampRepository;
            _bootcampBusinessRules = bootcampBusinessRules;
        }

        public async Task<CreatedBootcampResponse> Handle(CreateBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);

            await _bootcampRepository.AddAsync(bootcamp);

            CreatedBootcampResponse response = _mapper.Map<CreatedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
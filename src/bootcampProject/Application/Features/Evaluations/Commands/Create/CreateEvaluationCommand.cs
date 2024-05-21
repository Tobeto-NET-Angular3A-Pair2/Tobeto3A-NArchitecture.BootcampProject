using Application.Features.Evaluations.Constants;
using Application.Features.Evaluations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Evaluations.Constants.EvaluationsOperationClaims;

namespace Application.Features.Evaluations.Commands.Create;

public class CreateEvaluationCommand
    : IRequest<CreatedEvaluationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Criteria { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, EvaluationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvaluations"];

    public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, CreatedEvaluationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public CreateEvaluationCommandHandler(
            IMapper mapper,
            IEvaluationRepository evaluationRepository,
            EvaluationBusinessRules evaluationBusinessRules
        )
        {
            _mapper = mapper;
            _evaluationRepository = evaluationRepository;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<CreatedEvaluationResponse> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            Evaluation evaluation = _mapper.Map<Evaluation>(request);

            await _evaluationRepository.AddAsync(evaluation);

            CreatedEvaluationResponse response = _mapper.Map<CreatedEvaluationResponse>(evaluation);
            return response;
        }
    }
}

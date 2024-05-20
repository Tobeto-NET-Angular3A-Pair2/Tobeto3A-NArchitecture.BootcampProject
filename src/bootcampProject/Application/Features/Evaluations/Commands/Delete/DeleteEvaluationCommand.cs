using Application.Features.Evaluations.Constants;
using Application.Features.Evaluations.Constants;
using Application.Features.Evaluations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Evaluations.Constants.EvaluationsOperationClaims;

namespace Application.Features.Evaluations.Commands.Delete;

public class DeleteEvaluationCommand : IRequest<DeletedEvaluationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, EvaluationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvaluations"];

    public class DeleteEvaluationCommandHandler : IRequestHandler<DeleteEvaluationCommand, DeletedEvaluationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteEvaluationCommandHandler(IMapper mapper, IEvaluationRepository evaluationRepository,
                                         EvaluationBusinessRules evaluationBusinessRules)
        {
            _mapper = mapper;
            _evaluationRepository = evaluationRepository;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeletedEvaluationResponse> Handle(DeleteEvaluationCommand request, CancellationToken cancellationToken)
        {
            Evaluation? evaluation = await _evaluationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _evaluationBusinessRules.EvaluationShouldExistWhenSelected(evaluation);

            await _evaluationRepository.DeleteAsync(evaluation!);

            DeletedEvaluationResponse response = _mapper.Map<DeletedEvaluationResponse>(evaluation);
            return response;
        }
    }
}
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

namespace Application.Features.Evaluations.Commands.Update;

public class UpdateEvaluationCommand : IRequest<UpdatedEvaluationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Criteria { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, EvaluationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvaluations"];

    public class UpdateEvaluationCommandHandler : IRequestHandler<UpdateEvaluationCommand, UpdatedEvaluationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public UpdateEvaluationCommandHandler(IMapper mapper, IEvaluationRepository evaluationRepository,
                                         EvaluationBusinessRules evaluationBusinessRules)
        {
            _mapper = mapper;
            _evaluationRepository = evaluationRepository;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<UpdatedEvaluationResponse> Handle(UpdateEvaluationCommand request, CancellationToken cancellationToken)
        {
            Evaluation? evaluation = await _evaluationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _evaluationBusinessRules.EvaluationShouldExistWhenSelected(evaluation);
            evaluation = _mapper.Map(request, evaluation);

            await _evaluationRepository.UpdateAsync(evaluation!);

            UpdatedEvaluationResponse response = _mapper.Map<UpdatedEvaluationResponse>(evaluation);
            return response;
        }
    }
}
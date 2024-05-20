using Application.Features.Evaluations.Constants;
using Application.Features.Evaluations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Evaluations.Constants.EvaluationsOperationClaims;

namespace Application.Features.Evaluations.Queries.GetById;

public class GetByIdEvaluationQuery : IRequest<GetByIdEvaluationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEvaluationQueryHandler : IRequestHandler<GetByIdEvaluationQuery, GetByIdEvaluationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public GetByIdEvaluationQueryHandler(IMapper mapper, IEvaluationRepository evaluationRepository, EvaluationBusinessRules evaluationBusinessRules)
        {
            _mapper = mapper;
            _evaluationRepository = evaluationRepository;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<GetByIdEvaluationResponse> Handle(GetByIdEvaluationQuery request, CancellationToken cancellationToken)
        {
            Evaluation? evaluation = await _evaluationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _evaluationBusinessRules.EvaluationShouldExistWhenSelected(evaluation);

            GetByIdEvaluationResponse response = _mapper.Map<GetByIdEvaluationResponse>(evaluation);
            return response;
        }
    }
}
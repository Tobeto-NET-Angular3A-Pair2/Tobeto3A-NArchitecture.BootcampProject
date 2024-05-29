using Application.Features.Evaluations.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Evaluations.Rules;

public class EvaluationBusinessRules : BaseBusinessRules
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly ILocalizationService _localizationService;

    public EvaluationBusinessRules(IEvaluationRepository evaluationRepository, ILocalizationService localizationService)
    {
        _evaluationRepository = evaluationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EvaluationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EvaluationShouldExistWhenSelected(Evaluation? evaluation)
    {
        if (evaluation == null)
            await throwBusinessException(EvaluationsBusinessMessages.EvaluationNotExists);
    }

    public async Task EvaluationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Evaluation? evaluation = await _evaluationRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EvaluationShouldExistWhenSelected(evaluation);
    }
}

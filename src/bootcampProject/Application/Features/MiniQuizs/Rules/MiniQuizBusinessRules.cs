using Application.Features.MiniQuizs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MiniQuizs.Rules;

public class MiniQuizBusinessRules : BaseBusinessRules
{
    private readonly IMiniQuizRepository _miniQuizRepository;
    private readonly ILocalizationService _localizationService;

    public MiniQuizBusinessRules(IMiniQuizRepository miniQuizRepository, ILocalizationService localizationService)
    {
        _miniQuizRepository = miniQuizRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MiniQuizsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MiniQuizShouldExistWhenSelected(MiniQuiz? miniQuiz)
    {
        if (miniQuiz == null)
            await throwBusinessException(MiniQuizsBusinessMessages.MiniQuizNotExists);
    }

    public async Task MiniQuizIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        MiniQuiz? miniQuiz = await _miniQuizRepository.GetAsync(
            predicate: mq => mq.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MiniQuizShouldExistWhenSelected(miniQuiz);
    }
}
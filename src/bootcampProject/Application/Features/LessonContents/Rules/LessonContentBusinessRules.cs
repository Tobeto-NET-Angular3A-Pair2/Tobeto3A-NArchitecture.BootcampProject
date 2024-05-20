using Application.Features.LessonContents.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.LessonContents.Rules;

public class LessonContentBusinessRules : BaseBusinessRules
{
    private readonly ILessonContentRepository _lessonContentRepository;
    private readonly ILocalizationService _localizationService;

    public LessonContentBusinessRules(ILessonContentRepository lessonContentRepository, ILocalizationService localizationService)
    {
        _lessonContentRepository = lessonContentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LessonContentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LessonContentShouldExistWhenSelected(LessonContent? lessonContent)
    {
        if (lessonContent == null)
            await throwBusinessException(LessonContentsBusinessMessages.LessonContentNotExists);
    }

    public async Task LessonContentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonContent? lessonContent = await _lessonContentRepository.GetAsync(
            predicate: lc => lc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonContentShouldExistWhenSelected(lessonContent);
    }
}
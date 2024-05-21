using Application.Features.LessonVideos.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.LessonVideos.Rules;

public class LessonVideoBusinessRules : BaseBusinessRules
{
    private readonly ILessonVideoRepository _lessonVideoRepository;
    private readonly ILocalizationService _localizationService;

    public LessonVideoBusinessRules(ILessonVideoRepository lessonVideoRepository, ILocalizationService localizationService)
    {
        _lessonVideoRepository = lessonVideoRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LessonVideosBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LessonVideoShouldExistWhenSelected(LessonVideo? lessonVideo)
    {
        if (lessonVideo == null)
            await throwBusinessException(LessonVideosBusinessMessages.LessonVideoNotExists);
    }

    public async Task LessonVideoIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonVideo? lessonVideo = await _lessonVideoRepository.GetAsync(
            predicate: lv => lv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonVideoShouldExistWhenSelected(lessonVideo);
    }
}

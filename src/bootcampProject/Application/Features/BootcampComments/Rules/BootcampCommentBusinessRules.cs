using Application.Features.BootcampComments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Announcements.Constants;

namespace Application.Features.BootcampComments.Rules;

public class BootcampCommentBusinessRules : BaseBusinessRules
{
    private readonly IBootcampCommentRepository _bootcampCommentRepository;
    private readonly ILocalizationService _localizationService;

    public BootcampCommentBusinessRules(IBootcampCommentRepository bootcampCommentRepository, ILocalizationService localizationService)
    {
        _bootcampCommentRepository = bootcampCommentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BootcampCommentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BootcampCommentShouldExistWhenSelected(BootcampComment? bootcampComment)
    {
        if (bootcampComment == null)
            await throwBusinessException(BootcampCommentsBusinessMessages.BootcampCommentNotExists);
    }

    public async Task BootcampCommentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BootcampComment? bootcampComment = await _bootcampCommentRepository.GetAsync(
            predicate: bc => bc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BootcampCommentShouldExistWhenSelected(bootcampComment);
    }

    public async Task BootcampContextShouldBeExist(string context) 
    { 
        if(context == null)
            await throwBusinessException(BootcampCommentsBusinessMessages.ContextShouldExists);
    }
}
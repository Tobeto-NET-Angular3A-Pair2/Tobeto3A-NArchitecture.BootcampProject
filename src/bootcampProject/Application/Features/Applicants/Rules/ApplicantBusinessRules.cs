using Application.Features.Applicants.Constants;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Applicants.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository, ILocalizationService localizationService)
    {
        _applicantRepository = applicantRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ApplicantsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ApplicantShouldExistWhenSelected(Applicant? applicant)
    {
        if (applicant == null)
            await throwBusinessException(ApplicantsBusinessMessages.ApplicantNotExists);
    }

    public async Task ApplicantIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Applicant? applicant = await _applicantRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicantShouldExistWhenSelected(applicant);
    }

    public async Task ApplicantPasswordShouldBeMatched(Applicant applicant, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, applicant.PasswordHash, applicant.PasswordSalt))
            await throwBusinessException(ApplicantsBusinessMessages.PasswordDontMatch);
    }

    public async Task ApplicantEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _applicantRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(ApplicantsBusinessMessages.UserMailAlreadyExists);
    }

    public async Task ApplicantEmailShouldNotExistsWhenUpdate(Guid id, string email)
    {
        bool doesExists = await _applicantRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email);
        if (doesExists)
            await throwBusinessException(ApplicantsBusinessMessages.UserMailAlreadyExists);
    }
}

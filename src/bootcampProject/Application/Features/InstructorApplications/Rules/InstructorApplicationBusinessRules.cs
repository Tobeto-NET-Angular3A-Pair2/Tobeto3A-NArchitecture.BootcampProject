using Application.Features.InstructorApplications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;

namespace Application.Features.InstructorApplications.Rules;

public class InstructorApplicationBusinessRules : BaseBusinessRules
{
    private readonly IInstructorApplicationRepository _instructorApplicationRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public InstructorApplicationBusinessRules(IInstructorApplicationRepository instructorApplicationRepository, ILocalizationService localizationService)
    {
        _instructorApplicationRepository = instructorApplicationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InstructorApplicationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InstructorApplicationShouldExistWhenSelected(InstructorApplication? instructorApplication)
    {
        if (instructorApplication == null)
            await throwBusinessException(InstructorApplicationsBusinessMessages.InstructorApplicationNotExists);
    }

    public async Task InstructorApplicationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(
            predicate: ia => ia.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InstructorApplicationShouldExistWhenSelected(instructorApplication);
    }

    public async Task InstructorApplicationEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _instructorApplicationRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(InstructorApplicationsBusinessMessages.InstructorApplicationMailAlreadyExists);
    }

    public async Task UserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }
}
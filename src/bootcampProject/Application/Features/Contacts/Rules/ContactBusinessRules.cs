using Application.Features.Contacts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Contacts.Rules;

public class ContactBusinessRules : BaseBusinessRules
{
    private readonly IContactRepository _contactRepository;
    private readonly ILocalizationService _localizationService;

    public ContactBusinessRules(IContactRepository contactRepository, ILocalizationService localizationService)
    {
        _contactRepository = contactRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ContactsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ContactShouldExistWhenSelected(Contact? contact)
    {
        if (contact == null)
            await throwBusinessException(ContactsBusinessMessages.ContactNotExists);
    }

    public async Task ContactIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Contact? contact = await _contactRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ContactShouldExistWhenSelected(contact);
    }

    public async Task ContactEmailShoulBeExists(string email)
    {
        if (email == null)
            await throwBusinessException(ContactsBusinessMessages.EmailNotExists);
    }

    public async Task ContactPhoneShouldBeExists(string phoneNumber)
    {
        if (phoneNumber == null)
            await throwBusinessException(ContactsBusinessMessages.PhoneNotExists);
    }

    public async Task ContactMessageShouldExist(string message)
    {
        if (message == null)
            await throwBusinessException(ContactsBusinessMessages.MessageNotExists);
    }

}
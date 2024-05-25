using Application.Features.Contacts.Constants;
using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Contacts.Constants.ContactsOperationClaims;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommand
    : IRequest<UpdatedContactResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public string[] Roles => [Admin, Write, ContactsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetContacts"];

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdatedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public UpdateContactCommandHandler(
            IMapper mapper,
            IContactRepository contactRepository,
            ContactBusinessRules contactBusinessRules
        )
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<UpdatedContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(
                predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _contactBusinessRules.ContactShouldExistWhenSelected(contact);
            await _contactBusinessRules.ContactEmailShoulBeExists(request.Email);
            await _contactBusinessRules.ContactPhoneShouldBeExists(request.PhoneNumber);
            await _contactBusinessRules.ContactMessageShouldExist(request.Message);
            contact = _mapper.Map(request, contact);

            await _contactRepository.UpdateAsync(contact!);

            UpdatedContactResponse response = _mapper.Map<UpdatedContactResponse>(contact);
            return response;
        }
    }
}

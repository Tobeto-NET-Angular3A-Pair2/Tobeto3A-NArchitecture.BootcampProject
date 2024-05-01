using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommand : IRequest<CreatedContactResponse>,  ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetContacts"];

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreatedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository,
                                         ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<CreatedContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _contactBusinessRules.ContactEmailShoulBeExists(request.Email);
            await _contactBusinessRules.ContactPhoneShouldBeExists(request.PhoneNumber);
            await _contactBusinessRules.ContactMessageShouldExist(request.Message);

            Contact contact = _mapper.Map<Contact>(request);

            await _contactRepository.AddAsync(contact);

            CreatedContactResponse response = _mapper.Map<CreatedContactResponse>(contact);
            return response;
        }
    }
}
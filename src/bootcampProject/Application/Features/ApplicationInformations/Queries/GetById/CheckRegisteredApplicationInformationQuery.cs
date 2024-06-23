using Application.Features.Applicants.Constants;
using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ApplicationInformations.Queries.GetById
{
    public class CheckRegisteredApplicationInformationQuery : IRequest<bool>, ISecuredRequest
    {
        public int BootcampId { get; set; }
        public Guid ApplicantId { get; set; }

        public string[] Roles => new[]
        {
            ApplicationInformationsOperationClaims.Admin,
            ApplicantsOperationClaims.Admin
        };

        public class CheckRegisteredApplicationInformationQueryHandler
            : IRequestHandler<CheckRegisteredApplicationInformationQuery, bool>
        {
            private readonly IMapper _mapper;
            private readonly IApplicationInformationRepository _applicationInformationRepository;
            private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

            public CheckRegisteredApplicationInformationQueryHandler(
                IMapper mapper,
                IApplicationInformationRepository applicationInformationRepository,
                ApplicationInformationBusinessRules applicationInformationBusinessRules
            )
            {
                _mapper = mapper;
                _applicationInformationRepository = applicationInformationRepository;
                _applicationInformationBusinessRules = applicationInformationBusinessRules;
            }

            public async Task<bool> Handle(
                CheckRegisteredApplicationInformationQuery request,
                CancellationToken cancellationToken
            )
            {
                ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
                    predicate: ai => ai.BootcampId == request.BootcampId && ai.ApplicantId == request.ApplicantId,
                    cancellationToken: cancellationToken
                );

                if (applicationInformation == null)
                {
                    return false; // Başvuru bilgisi bulunamadı
                }

                // İş kurallarını kontrol et
                await _applicationInformationBusinessRules.ApplicationInformationShouldExistWhenSelected(applicationInformation);

                // Başvuru bilgisi bulundu ise true dön
                return true;
            }
        }
    }
}

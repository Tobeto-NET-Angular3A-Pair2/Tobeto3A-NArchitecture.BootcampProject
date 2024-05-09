using Application.Features.Settings.Constants;
using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Settings.Constants.SettingsOperationClaims;

namespace Application.Features.Settings.Commands.Update;

public class UpdateSettingCommand
    : IRequest<UpdatedSettingResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Keywords { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? GoogleSiteKey { get; set; }
    public string? GoogleSecretKey { get; set; }
    public string? GoogleAnalytics { get; set; }
    public string LogoUrl { get; set; }
    public string FaviconUrl { get; set; }
    public Boolean MaintenanceMode { get; set; }
    public string TermsOfUse { get; set; }
    public string PrivacyPolicy { get; set; }

    public string[] Roles => [Admin, Write, SettingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSettings"];

    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, UpdatedSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public UpdateSettingCommandHandler(
            IMapper mapper,
            ISettingRepository settingRepository,
            SettingBusinessRules settingBusinessRules
        )
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<UpdatedSettingResponse> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            Setting? setting = await _settingRepository.GetAsync(
                predicate: s => s.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _settingBusinessRules.SettingShouldExistWhenSelected(setting);
            setting = _mapper.Map(request, setting);

            await _settingRepository.UpdateAsync(setting!);

            UpdatedSettingResponse response = _mapper.Map<UpdatedSettingResponse>(setting);
            return response;
        }
    }
}

using Application.Features.Settings.Commands.Update;
using Application.Features.Settings.Queries.GetById;
using Application.Features.Settings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Settings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Setting, UpdateSettingCommand>().ReverseMap();
        CreateMap<Setting, UpdatedSettingResponse>().ReverseMap();
        CreateMap<Setting, GetByIdSettingResponse>().ReverseMap();
        CreateMap<Setting, GetListSettingListItemDto>().ReverseMap();
        CreateMap<IPaginate<Setting>, GetListResponse<GetListSettingListItemDto>>().ReverseMap();
    }
}
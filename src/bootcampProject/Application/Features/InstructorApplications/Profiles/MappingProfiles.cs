using Application.Features.InstructorApplications.Commands.Create;
using Application.Features.InstructorApplications.Commands.Delete;
using Application.Features.InstructorApplications.Commands.Update;
using Application.Features.InstructorApplications.Queries.GetById;
using Application.Features.InstructorApplications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.InstructorApplications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<InstructorApplication, CreateInstructorApplicationCommand>().ReverseMap();
        CreateMap<InstructorApplication, CreatedInstructorApplicationResponse>().ReverseMap();
        CreateMap<InstructorApplication, UpdateInstructorApplicationCommand>().ReverseMap();
        CreateMap<InstructorApplication, UpdatedInstructorApplicationResponse>().ReverseMap();
        CreateMap<InstructorApplication, DeleteInstructorApplicationCommand>().ReverseMap();
        CreateMap<InstructorApplication, DeletedInstructorApplicationResponse>().ReverseMap();
        CreateMap<InstructorApplication, GetByIdInstructorApplicationResponse>().ReverseMap();
        CreateMap<InstructorApplication, GetListInstructorApplicationListItemDto>().ReverseMap();
        CreateMap<IPaginate<InstructorApplication>, GetListResponse<GetListInstructorApplicationListItemDto>>().ReverseMap();
    }
}
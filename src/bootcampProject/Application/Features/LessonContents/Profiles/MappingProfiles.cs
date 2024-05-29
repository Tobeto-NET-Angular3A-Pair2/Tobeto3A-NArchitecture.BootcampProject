using Application.Features.LessonContents.Commands.Create;
using Application.Features.LessonContents.Commands.Delete;
using Application.Features.LessonContents.Commands.Update;
using Application.Features.LessonContents.Queries.GetById;
using Application.Features.LessonContents.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LessonContents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonContent, CreateLessonContentCommand>().ReverseMap();
        CreateMap<LessonContent, CreatedLessonContentResponse>().ReverseMap();
        CreateMap<LessonContent, UpdateLessonContentCommand>().ReverseMap();
        CreateMap<LessonContent, UpdatedLessonContentResponse>().ReverseMap();
        CreateMap<LessonContent, DeleteLessonContentCommand>().ReverseMap();
        CreateMap<LessonContent, DeletedLessonContentResponse>().ReverseMap();
        CreateMap<LessonContent, GetByIdLessonContentResponse>().ReverseMap();
        CreateMap<LessonContent, GetByLessonIdContentResponse>().ReverseMap();
        CreateMap<LessonContent, GetListLessonContentListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonContent>, GetListResponse<GetListLessonContentListItemDto>>().ReverseMap();
    }
}

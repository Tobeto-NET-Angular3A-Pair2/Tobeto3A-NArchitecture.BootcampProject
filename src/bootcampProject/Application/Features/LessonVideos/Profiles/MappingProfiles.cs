using Application.Features.LessonVideos.Commands.Create;
using Application.Features.LessonVideos.Commands.Delete;
using Application.Features.LessonVideos.Commands.Update;
using Application.Features.LessonVideos.Queries.GetById;
using Application.Features.LessonVideos.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LessonVideos.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonVideo, CreateLessonVideoCommand>().ReverseMap();
        CreateMap<LessonVideo, CreatedLessonVideoResponse>().ReverseMap();
        CreateMap<LessonVideo, UpdateLessonVideoCommand>().ReverseMap();
        CreateMap<LessonVideo, UpdatedLessonVideoResponse>().ReverseMap();
        CreateMap<LessonVideo, DeleteLessonVideoCommand>().ReverseMap();
        CreateMap<LessonVideo, DeletedLessonVideoResponse>().ReverseMap();
        CreateMap<LessonVideo, GetByIdLessonVideoResponse>().ReverseMap();
        CreateMap<LessonVideo, GetListLessonVideoListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonVideo>, GetListResponse<GetListLessonVideoListItemDto>>().ReverseMap();
    }
}
using Application.Features.Bootcamps.Queries.GetList;
using Application.Features.Lessons.Commands.Create;
using Application.Features.Lessons.Commands.Delete;
using Application.Features.Lessons.Commands.Update;
using Application.Features.Lessons.Queries.GetById;
using Application.Features.Lessons.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Lessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Lesson, CreateLessonCommand>().ReverseMap();
        CreateMap<Lesson, CreatedLessonResponse>().ReverseMap();
        CreateMap<Lesson, UpdateLessonCommand>().ReverseMap();
        CreateMap<Lesson, UpdatedLessonResponse>().ReverseMap();
        CreateMap<Lesson, DeleteLessonCommand>().ReverseMap();
        CreateMap<Lesson, DeletedLessonResponse>().ReverseMap();
        CreateMap<Lesson, GetByIdLessonResponse>().ReverseMap();
        CreateMap<Lesson, GetListLessonListItemDto>().ReverseMap();
        CreateMap<Lesson, GetListBootcampLessonItemDto>().ReverseMap();
        CreateMap<Paginate<Lesson>, GetListResponse<GetListBootcampLessonItemDto>>();
        CreateMap<IPaginate<Lesson>, GetListResponse<GetListLessonListItemDto>>().ReverseMap();
     

    }
}

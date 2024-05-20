using Application.Features.MiniQuizs.Commands.Create;
using Application.Features.MiniQuizs.Commands.Delete;
using Application.Features.MiniQuizs.Commands.Update;
using Application.Features.MiniQuizs.Queries.GetById;
using Application.Features.MiniQuizs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MiniQuizs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MiniQuiz, CreateMiniQuizCommand>().ReverseMap();
        CreateMap<MiniQuiz, CreatedMiniQuizResponse>().ReverseMap();
        CreateMap<MiniQuiz, UpdateMiniQuizCommand>().ReverseMap();
        CreateMap<MiniQuiz, UpdatedMiniQuizResponse>().ReverseMap();
        CreateMap<MiniQuiz, DeleteMiniQuizCommand>().ReverseMap();
        CreateMap<MiniQuiz, DeletedMiniQuizResponse>().ReverseMap();
        CreateMap<MiniQuiz, GetByIdMiniQuizResponse>().ReverseMap();
        CreateMap<MiniQuiz, GetListMiniQuizListItemDto>().ReverseMap();
        CreateMap<IPaginate<MiniQuiz>, GetListResponse<GetListMiniQuizListItemDto>>().ReverseMap();
    }
}
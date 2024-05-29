using Application.Features.Evaluations.Commands.Create;
using Application.Features.Evaluations.Commands.Delete;
using Application.Features.Evaluations.Commands.Update;
using Application.Features.Evaluations.Queries.GetById;
using Application.Features.Evaluations.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Evaluations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Evaluation, CreateEvaluationCommand>().ReverseMap();
        CreateMap<Evaluation, CreatedEvaluationResponse>().ReverseMap();
        CreateMap<Evaluation, UpdateEvaluationCommand>().ReverseMap();
        CreateMap<Evaluation, UpdatedEvaluationResponse>().ReverseMap();
        CreateMap<Evaluation, DeleteEvaluationCommand>().ReverseMap();
        CreateMap<Evaluation, DeletedEvaluationResponse>().ReverseMap();
        CreateMap<Evaluation, GetByIdEvaluationResponse>().ReverseMap();
        CreateMap<Evaluation, GetListEvaluationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Evaluation>, GetListResponse<GetListEvaluationListItemDto>>().ReverseMap();
    }
}

using Application.Features.BootcampComments.Commands.Create;
using Application.Features.BootcampComments.Commands.Delete;
using Application.Features.BootcampComments.Commands.Update;
using Application.Features.BootcampComments.Queries.GetById;
using Application.Features.BootcampComments.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BootcampComments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampComment, CreateBootcampCommentCommand>().ReverseMap();
        CreateMap<BootcampComment, CreatedBootcampCommentResponse>().ReverseMap();
        CreateMap<BootcampComment, UpdateBootcampCommentCommand>().ReverseMap();
        CreateMap<BootcampComment, UpdatedBootcampCommentResponse>().ReverseMap();
        CreateMap<BootcampComment, DeleteBootcampCommentCommand>().ReverseMap();
        CreateMap<BootcampComment, DeletedBootcampCommentResponse>().ReverseMap();
        CreateMap<BootcampComment, GetByIdBootcampCommentResponse>().ReverseMap();
        CreateMap<BootcampComment, GetListBootcampCommentListItemDto>().ReverseMap();
        CreateMap<IPaginate<BootcampComment>, GetListResponse<GetListBootcampCommentListItemDto>>().ReverseMap();
    }
}

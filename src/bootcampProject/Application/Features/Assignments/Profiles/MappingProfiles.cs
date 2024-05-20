using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
using Application.Features.Assignments.Queries.GetById;
using Application.Features.Assignments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Assignments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Assignment, CreateAssignmentCommand>().ReverseMap();
        CreateMap<Assignment, CreatedAssignmentResponse>().ReverseMap();
        CreateMap<Assignment, UpdateAssignmentCommand>().ReverseMap();
        CreateMap<Assignment, UpdatedAssignmentResponse>().ReverseMap();
        CreateMap<Assignment, DeleteAssignmentCommand>().ReverseMap();
        CreateMap<Assignment, DeletedAssignmentResponse>().ReverseMap();
        CreateMap<Assignment, GetByIdAssignmentResponse>().ReverseMap();
        CreateMap<Assignment, GetListAssignmentListItemDto>().ReverseMap();
        CreateMap<IPaginate<Assignment>, GetListResponse<GetListAssignmentListItemDto>>().ReverseMap();
    }
}
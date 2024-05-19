using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Messages.Queries.GetChatUserList;

namespace Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Message, CreateMessageCommand>().ReverseMap();
        CreateMap<Message, CreatedMessageResponse>().ReverseMap();
        CreateMap<Message, UpdateMessageCommand>().ReverseMap();
        CreateMap<Message, UpdatedMessageResponse>().ReverseMap();
        CreateMap<Message, DeleteMessageCommand>().ReverseMap();
        CreateMap<Message, DeletedMessageResponse>().ReverseMap();
        CreateMap<Message, GetByIdMessageResponse>().ReverseMap();
        CreateMap<Message, GetListMessageListItemDto>().ReverseMap();
        CreateMap<IPaginate<Message>, GetListResponse<GetListMessageListItemDto>>().ReverseMap();

        CreateMap<User, GetChatUserListItemDto>().ReverseMap();
        CreateMap<IPaginate<User>, GetListResponse<GetChatUserListItemDto>>().ReverseMap();
    }
}
using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Queries.GetChatUserList;
using Application.Features.Messages.Queries.GetList;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Nest;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ChatsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetChats([FromQuery] GetListMessageQuery getListMessageQuery, CancellationToken cancellationToken)
    {
        GetListResponse<GetListMessageListItemDto> response = await Mediator.Send(getListMessageQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetChatHistory([FromQuery] GetChatUserListQuery getChatUserListQuery, CancellationToken cancellationToken)
    {
        GetListResponse<GetChatUserListItemDto> response = await Mediator.Send(getChatUserListQuery);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] CreateMessageCommand createMessageCommand, CancellationToken cancellationToken)
    {
        CreatedMessageResponse response = await Mediator.Send(createMessageCommand);

        return Created(uri: "", response);
    }
}

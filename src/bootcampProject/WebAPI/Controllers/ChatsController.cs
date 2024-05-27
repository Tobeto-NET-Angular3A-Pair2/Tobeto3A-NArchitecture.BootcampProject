using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.DeleteChat;
using Application.Features.Messages.Queries.GetChatUserList;
using Application.Features.Messages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage([FromRoute] int id)
    {
        DeletedMessageResponse response = await Mediator.Send(new DeleteMessageCommand { Id = id });

        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteChat([FromBody] DeleteChatCommand command, CancellationToken cancellationToken)
    {
        DeletedChatResponse response = await Mediator.Send(command);

        return Ok(response);
    }
}

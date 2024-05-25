using Application.Features.BootcampComments.Commands.Create;
using Application.Features.BootcampComments.Commands.Delete;
using Application.Features.BootcampComments.Commands.Update;
using Application.Features.BootcampComments.Queries.GetById;
using Application.Features.BootcampComments.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampCommentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBootcampCommentCommand createBootcampCommentCommand)
    {
        CreatedBootcampCommentResponse response = await Mediator.Send(createBootcampCommentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBootcampCommentCommand updateBootcampCommentCommand)
    {
        UpdatedBootcampCommentResponse response = await Mediator.Send(updateBootcampCommentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBootcampCommentResponse response = await Mediator.Send(new DeleteBootcampCommentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBootcampCommentResponse response = await Mediator.Send(new GetByIdBootcampCommentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBootcampCommentQuery getListBootcampCommentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBootcampCommentListItemDto> response = await Mediator.Send(getListBootcampCommentQuery);
        return Ok(response);
    }
}

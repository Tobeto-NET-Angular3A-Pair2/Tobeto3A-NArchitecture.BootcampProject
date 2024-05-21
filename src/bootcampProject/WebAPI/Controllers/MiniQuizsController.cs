using Application.Features.MiniQuizs.Commands.Create;
using Application.Features.MiniQuizs.Commands.Delete;
using Application.Features.MiniQuizs.Commands.Update;
using Application.Features.MiniQuizs.Queries.GetById;
using Application.Features.MiniQuizs.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MiniQuizsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMiniQuizCommand createMiniQuizCommand)
    {
        CreatedMiniQuizResponse response = await Mediator.Send(createMiniQuizCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMiniQuizCommand updateMiniQuizCommand)
    {
        UpdatedMiniQuizResponse response = await Mediator.Send(updateMiniQuizCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedMiniQuizResponse response = await Mediator.Send(new DeleteMiniQuizCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdMiniQuizResponse response = await Mediator.Send(new GetByIdMiniQuizQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMiniQuizQuery getListMiniQuizQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMiniQuizListItemDto> response = await Mediator.Send(getListMiniQuizQuery);
        return Ok(response);
    }
}

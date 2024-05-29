using Application.Features.Evaluations.Commands.Create;
using Application.Features.Evaluations.Commands.Delete;
using Application.Features.Evaluations.Commands.Update;
using Application.Features.Evaluations.Queries.GetById;
using Application.Features.Evaluations.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EvaluationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEvaluationCommand createEvaluationCommand)
    {
        CreatedEvaluationResponse response = await Mediator.Send(createEvaluationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEvaluationCommand updateEvaluationCommand)
    {
        UpdatedEvaluationResponse response = await Mediator.Send(updateEvaluationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEvaluationResponse response = await Mediator.Send(new DeleteEvaluationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEvaluationResponse response = await Mediator.Send(new GetByIdEvaluationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEvaluationQuery getListEvaluationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEvaluationListItemDto> response = await Mediator.Send(getListEvaluationQuery);
        return Ok(response);
    }
}

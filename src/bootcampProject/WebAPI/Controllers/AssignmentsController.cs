using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
using Application.Features.Assignments.Queries.GetById;
using Application.Features.Assignments.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAssignmentCommand createAssignmentCommand)
    {
        CreatedAssignmentResponse response = await Mediator.Send(createAssignmentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAssignmentCommand updateAssignmentCommand)
    {
        UpdatedAssignmentResponse response = await Mediator.Send(updateAssignmentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAssignmentResponse response = await Mediator.Send(new DeleteAssignmentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAssignmentResponse response = await Mediator.Send(new GetByIdAssignmentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAssignmentQuery getListAssignmentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAssignmentListItemDto> response = await Mediator.Send(getListAssignmentQuery);
        return Ok(response);
    }
}

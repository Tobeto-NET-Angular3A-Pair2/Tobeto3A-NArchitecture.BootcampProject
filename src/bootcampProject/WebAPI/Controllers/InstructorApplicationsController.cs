using Application.Features.InstructorApplications.Commands.Create;
using Application.Features.InstructorApplications.Commands.Delete;
using Application.Features.InstructorApplications.Commands.Update;
using Application.Features.InstructorApplications.Queries.GetById;
using Application.Features.InstructorApplications.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInstructorApplicationCommand createInstructorApplicationCommand)
    {
        CreatedInstructorApplicationResponse response = await Mediator.Send(createInstructorApplicationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInstructorApplicationCommand updateInstructorApplicationCommand)
    {
        UpdatedInstructorApplicationResponse response = await Mediator.Send(updateInstructorApplicationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedInstructorApplicationResponse response = await Mediator.Send(new DeleteInstructorApplicationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdInstructorApplicationResponse response = await Mediator.Send(new GetByIdInstructorApplicationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInstructorApplicationQuery getListInstructorApplicationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListInstructorApplicationListItemDto> response = await Mediator.Send(
            getListInstructorApplicationQuery
        );
        return Ok(response);
    }
}

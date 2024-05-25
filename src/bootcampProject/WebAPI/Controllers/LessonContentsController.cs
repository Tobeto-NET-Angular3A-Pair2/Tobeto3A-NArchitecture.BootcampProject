using Application.Features.LessonContents.Commands.Create;
using Application.Features.LessonContents.Commands.Delete;
using Application.Features.LessonContents.Commands.Update;
using Application.Features.LessonContents.Queries.GetById;
using Application.Features.LessonContents.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonContentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonContentCommand createLessonContentCommand)
    {
        CreatedLessonContentResponse response = await Mediator.Send(createLessonContentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonContentCommand updateLessonContentCommand)
    {
        UpdatedLessonContentResponse response = await Mediator.Send(updateLessonContentCommand);

        return Ok(response);
    }

    [HttpDelete("{LessonId}")]
    public async Task<IActionResult> Delete([FromRoute] int LessonId)
    {
        DeletedLessonContentResponse response = await Mediator.Send(new DeleteLessonContentCommand { LessonId = LessonId });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonContentResponse response = await Mediator.Send(new GetByIdLessonContentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonContentQuery getListLessonContentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonContentListItemDto> response = await Mediator.Send(getListLessonContentQuery);
        return Ok(response);
    }
    [HttpGet("lesson/{LessonId}")]
    public async Task<IActionResult> GetByLessonId([FromRoute] int LessonId)
    {
        GetByLessonIdContentResponse response = await Mediator.Send(new GetByLessonIdContentQuery { LessonId = LessonId });
        return Ok(response);
    }
}

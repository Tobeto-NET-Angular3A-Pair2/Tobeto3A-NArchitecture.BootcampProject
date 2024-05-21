using Application.Features.LessonVideos.Commands.Create;
using Application.Features.LessonVideos.Commands.Delete;
using Application.Features.LessonVideos.Commands.Update;
using Application.Features.LessonVideos.Queries.GetById;
using Application.Features.LessonVideos.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonVideosController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonVideoCommand createLessonVideoCommand)
    {
        CreatedLessonVideoResponse response = await Mediator.Send(createLessonVideoCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonVideoCommand updateLessonVideoCommand)
    {
        UpdatedLessonVideoResponse response = await Mediator.Send(updateLessonVideoCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLessonVideoResponse response = await Mediator.Send(new DeleteLessonVideoCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonVideoResponse response = await Mediator.Send(new GetByIdLessonVideoQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonVideoQuery getListLessonVideoQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonVideoListItemDto> response = await Mediator.Send(getListLessonVideoQuery);
        return Ok(response);
    }
}

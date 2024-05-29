using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListBootcampLessonItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int BootcampId { get; set; }
}

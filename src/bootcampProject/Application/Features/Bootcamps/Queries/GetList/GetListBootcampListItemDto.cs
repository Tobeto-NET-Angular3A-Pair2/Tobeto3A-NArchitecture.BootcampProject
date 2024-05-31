using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListBootcampListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid InstructorId { get; set; }
    public Boolean BootcampState { get; set; }
    public string BootcampImage { get; set; }
    public int Count { get; set; }
}

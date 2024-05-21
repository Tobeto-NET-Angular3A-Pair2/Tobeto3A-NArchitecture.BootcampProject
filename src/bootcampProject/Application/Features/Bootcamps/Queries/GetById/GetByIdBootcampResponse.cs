using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Queries.GetById;

public class GetByIdBootcampResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Boolean BootcampState { get; set; }
    public string BootcampImage { get; set; }
}
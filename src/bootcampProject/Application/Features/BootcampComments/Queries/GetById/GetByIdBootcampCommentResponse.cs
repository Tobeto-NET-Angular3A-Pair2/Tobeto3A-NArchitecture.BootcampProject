using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampComments.Queries.GetById;

public class GetByIdBootcampCommentResponse : IResponse
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }
}

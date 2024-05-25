using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampComments.Commands.Update;

public class UpdatedBootcampCommentResponse : IResponse
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }
}
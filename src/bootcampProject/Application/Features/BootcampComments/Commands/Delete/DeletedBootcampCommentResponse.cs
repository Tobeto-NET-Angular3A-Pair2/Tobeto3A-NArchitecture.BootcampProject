using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampComments.Commands.Delete;

public class DeletedBootcampCommentResponse : IResponse
{
    public int Id { get; set; }
}
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Assignments.Commands.Delete;

public class DeletedAssignmentResponse : IResponse
{
    public int Id { get; set; }
}

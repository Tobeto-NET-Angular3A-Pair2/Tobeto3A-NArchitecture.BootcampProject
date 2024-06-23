using NArchitecture.Core.Application.Responses;

namespace Application.Features.InstructorApplications.Commands.Delete;

public class DeletedInstructorApplicationResponse : IResponse
{
    public int Id { get; set; }
}

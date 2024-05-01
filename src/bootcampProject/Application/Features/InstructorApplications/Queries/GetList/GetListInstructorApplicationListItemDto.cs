using NArchitecture.Core.Application.Dtos;

namespace Application.Features.InstructorApplications.Queries.GetList;

public class GetListInstructorApplicationListItemDto : IDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? NationalIdentity { get; set; }
    public string? CompanyName { get; set; }
    public string? AdditionalInformation { get; set; }
    public string? Comment { get; set; }
    public bool? IsApproved { get; set; }
}
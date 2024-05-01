using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class InstructorApplication : Entity<int>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? NationalIdentity { get; set; }
    public string? CompanyName { get; set; }
    public string? AdditionalInformation { get; set; }
    public string? Comment { get; set; }
    public bool? IsApproved { get; set; }


    public InstructorApplication(
        int id,
        string email,
        string firstName,
        string lastName,
        DateTime? dateOfBirth,
        string? nationalIdentity,
        string? companyName,
        string? comment,
        string? additionalInformation,
        bool? isApproved = null)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        CompanyName = companyName;
        Comment = comment;
        IsApproved = isApproved;
        AdditionalInformation = additionalInformation;
    }
    public InstructorApplication() {}


}

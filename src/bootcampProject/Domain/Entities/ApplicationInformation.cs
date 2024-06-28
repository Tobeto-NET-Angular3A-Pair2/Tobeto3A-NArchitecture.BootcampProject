using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationInformation : Entity<int>
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public ApplicationInformation(int id, Guid applicantId, int bootcampId)
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
    }

    public ApplicationInformation() { }
}

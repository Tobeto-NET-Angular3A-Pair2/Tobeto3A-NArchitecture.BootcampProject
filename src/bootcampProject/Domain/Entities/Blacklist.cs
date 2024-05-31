using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Blacklist : Entity<int>
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid InstructorId { get; set; }

    public Instructor Instructor { get; set; }

    public Applicant Applicant { get; set; }

    public Blacklist(int id, string reason, DateTime date, Guid applicantId, Guid ınstructorId, Instructor ınstructor)
    {
        Id = id;
        Reason = reason;
        Date = date;
        ApplicantId = applicantId;
        InstructorId = ınstructorId;
        Instructor = ınstructor;
    }

    public Blacklist() { }
}

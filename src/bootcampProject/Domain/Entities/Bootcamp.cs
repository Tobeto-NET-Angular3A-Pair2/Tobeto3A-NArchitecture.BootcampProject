using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<int>
{
    //id,name,instructor_id,startDate,endDate,bootcampState_id
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BootcampStateId { get; set; }

    public virtual ICollection<ApplicationInformation>? Applications { get; set; }
    public virtual BootcampState BootcampState { get; set; }
    public virtual Instructor Instructor { get; set; }

    public Bootcamp(string name, Guid ınstructorId, DateTime startDate, DateTime endDate, int bootcampStateId)
        : this()
    {
        Name = name;
        InstructorId = ınstructorId;
        StartDate = startDate;
        EndDate = endDate;
        BootcampStateId = bootcampStateId;
    }

    public Bootcamp()
    {
        Applications = new HashSet<ApplicationInformation>();
    }
}

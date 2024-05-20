using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<int>
{
    //id,name,instructor_id,startDate,endDate,bootcampState_id
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Boolean BootcampState { get; set; }

    public virtual ICollection<ApplicationInformation>? Applications { get; set; }
    public virtual Instructor Instructor { get; set; }

    public Bootcamp(string name, Guid ınstructorId, Boolean bootcampState)
        : this()
    {
        Name = name;
        InstructorId = ınstructorId;
        BootcampState = bootcampState;
    }

    public Bootcamp()
    {
        Applications = new HashSet<ApplicationInformation>();
    }
}

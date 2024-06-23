using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BootcampImage { get; set; }
    public Guid InstructorId { get; set; }
    public Boolean BootcampState { get; set; }

    public virtual ICollection<ApplicationInformation>? Applications { get; set; }
    public virtual ICollection<BootcampComment>? BootcampComments { get; set; }
    public virtual Instructor Instructor { get; set; }

    public Bootcamp(string name, Guid ınstructorId, Boolean bootcampState, string bootcampImage, string description)
        : this()
    {
        Name = name;
        InstructorId = ınstructorId;
        BootcampState = bootcampState;
        BootcampImage = bootcampImage;
        Description = description;
    }

    public Bootcamp()
    {
        Applications = new HashSet<ApplicationInformation>();
    }
}

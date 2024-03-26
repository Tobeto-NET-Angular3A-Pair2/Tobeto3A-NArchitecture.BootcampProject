using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampState : Entity<int>
{
    //id,name
    public string Name { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }

    public BootcampState(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public BootcampState() { }
}

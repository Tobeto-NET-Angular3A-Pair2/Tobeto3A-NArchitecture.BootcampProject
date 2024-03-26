using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationState : Entity<int>
{
    //id,name
    public string Name { get; set; }
    public virtual ApplicationInformation? Application { get; set; }

    public ApplicationState(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ApplicationState() { }
}

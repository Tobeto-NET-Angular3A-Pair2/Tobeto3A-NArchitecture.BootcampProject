using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampComment : Entity<int>
{
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }

    public virtual User User { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }

    public BootcampComment() { }

    public BootcampComment(string context, Guid userId, int bootcampId)
    {
        Context = context;
        UserId = userId;
        BootcampId = bootcampId;
    }
}

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Announcement : Entity<int>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid InstructorId { get; set; }
    public virtual Instructor Instructor { get; set; }

    public Announcement()
    {
        
    }
    public Announcement(string title, string content, Guid instructorId)
    {
        Title = title;
        Content = content;
        InstructorId = instructorId;
    }
}

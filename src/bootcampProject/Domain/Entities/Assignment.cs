using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Assignment : Entity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }

    public Assignment(string title, string description, DateTime deadline, int lessonId)
        : this()
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        LessonId = lessonId;
    }

    public Assignment() { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Lesson : Entity<int>
{
    public string Title { get; set; }
    public int BootcampId { get; set; }
    public virtual ICollection<LessonContent>? Contents { get; set; }
    public virtual ICollection<Evaluation>? Evaluations { get; set; }

    public Lesson(string title)
        : this()
    {
        Title = title;
    }

    public Lesson()
    {
        Contents = new HashSet<LessonContent>();
        Evaluations = new HashSet<Evaluation>();
    }
}

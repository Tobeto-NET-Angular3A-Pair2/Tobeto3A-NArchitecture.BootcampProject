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
    public virtual ICollection<LessonVideo>? Videos { get; set; }
    public virtual ICollection<LessonContent>? Contents { get; set; }
    public virtual ICollection<MiniQuiz>? MiniQuizzes { get; set; }
    public virtual ICollection<Assignment>? Assignments { get; set; }
    public virtual ICollection<Evaluation>? Evaluations { get; set; }

    public Lesson(string title)
        : this()
    {
        Title = title;
    }

    public Lesson()
    {
        Videos = new HashSet<LessonVideo>();
        Contents = new HashSet<LessonContent>();
        MiniQuizzes = new HashSet<MiniQuiz>();
        Assignments = new HashSet<Assignment>();
        Evaluations = new HashSet<Evaluation>();
    }
}

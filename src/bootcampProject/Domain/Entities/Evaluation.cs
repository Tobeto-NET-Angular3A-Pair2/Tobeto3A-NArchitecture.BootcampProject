using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Evaluation : Entity<int>
{
    public string Criteria { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }

    public Evaluation(string criteria, int lessonId)
        : this()
    {
        Criteria = criteria;
        LessonId = lessonId;
    }

    public Evaluation() { }
}

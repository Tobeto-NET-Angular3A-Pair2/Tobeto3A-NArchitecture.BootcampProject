using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LessonVideo : Entity<int>
{
    public string Url { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }

    public LessonVideo(string url, int lessonId)
        : this()
    {
        Url = url;
        LessonId = lessonId;
    }

    public LessonVideo()
    {
    }
}
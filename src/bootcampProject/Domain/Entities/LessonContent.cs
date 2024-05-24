using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class LessonContent : Entity<int>
{
    public string? Text { get; set; }
    public string? VideoUrl { get; set; }
    public int? EvalationId { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }

    public LessonContent(string text, int lessonId, string videoUrl, int evalationId)
        : this()
    {
        Text = text;
        LessonId = lessonId;
        VideoUrl = videoUrl;
        EvalationId = evalationId;
    }

    public LessonContent() { }
}

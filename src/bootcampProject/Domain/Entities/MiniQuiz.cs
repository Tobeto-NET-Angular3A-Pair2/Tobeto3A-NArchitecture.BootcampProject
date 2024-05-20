using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MiniQuiz : Entity<int>
{
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }

    public MiniQuiz(string question, string correctAnswer, int lessonId)
        : this()
    {
        Question = question;
        CorrectAnswer = correctAnswer;
        LessonId = lessonId;
    }

    public MiniQuiz()
    {
    }
}
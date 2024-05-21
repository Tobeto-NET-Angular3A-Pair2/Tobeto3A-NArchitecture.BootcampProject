using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MiniQuizConfiguration : IEntityTypeConfiguration<MiniQuiz>
{
    public void Configure(EntityTypeBuilder<MiniQuiz> builder)
    {
        builder.ToTable("MiniQuizs").HasKey(mq => mq.Id);

        builder.Property(mq => mq.Id).HasColumnName("Id").IsRequired();
        builder.Property(mq => mq.Question).HasColumnName("Question");
        builder.Property(mq => mq.CorrectAnswer).HasColumnName("CorrectAnswer");
        builder.Property(mq => mq.LessonId).HasColumnName("LessonId");
        builder.Property(mq => mq.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mq => mq.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mq => mq.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mq => !mq.DeletedDate.HasValue);
    }
}

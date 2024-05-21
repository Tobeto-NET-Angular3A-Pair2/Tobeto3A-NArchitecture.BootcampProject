using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonContentConfiguration : IEntityTypeConfiguration<LessonContent>
{
    public void Configure(EntityTypeBuilder<LessonContent> builder)
    {
        builder.ToTable("LessonContents").HasKey(lc => lc.Id);

        builder.Property(lc => lc.Id).HasColumnName("Id").IsRequired();
        builder.Property(lc => lc.Text).HasColumnName("Text");
        builder.Property(lc => lc.LessonId).HasColumnName("LessonId");
        builder.Property(lc => lc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lc => lc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lc => lc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lc => !lc.DeletedDate.HasValue);
    }
}

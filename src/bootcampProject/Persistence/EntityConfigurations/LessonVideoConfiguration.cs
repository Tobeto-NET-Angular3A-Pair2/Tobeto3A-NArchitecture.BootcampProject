using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonVideoConfiguration : IEntityTypeConfiguration<LessonVideo>
{
    public void Configure(EntityTypeBuilder<LessonVideo> builder)
    {
        builder.ToTable("LessonVideos").HasKey(lv => lv.Id);

        builder.Property(lv => lv.Id).HasColumnName("Id").IsRequired();
        builder.Property(lv => lv.Url).HasColumnName("Url");
        builder.Property(lv => lv.LessonId).HasColumnName("LessonId");
        builder.Property(lv => lv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lv => lv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lv => lv.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lv => !lv.DeletedDate.HasValue);
    }
}

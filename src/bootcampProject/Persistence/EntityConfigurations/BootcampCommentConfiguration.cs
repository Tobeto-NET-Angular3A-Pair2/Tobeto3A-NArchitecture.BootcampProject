using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BootcampCommentConfiguration : IEntityTypeConfiguration<BootcampComment>
{
    public void Configure(EntityTypeBuilder<BootcampComment> builder)
    {
        builder.ToTable("BootcampComments").HasKey(bc => bc.Id);

        builder.Property(bc => bc.Id).HasColumnName("Id").IsRequired();
        builder.Property(bc => bc.Context).HasColumnName("Context");
        builder.Property(bc => bc.UserId).HasColumnName("UserId");
        builder.Property(bc => bc.BootcampId).HasColumnName("BootcampId");
        builder.Property(bc => bc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bc => bc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bc => bc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bc => !bc.DeletedDate.HasValue);

        builder.HasOne(x => x.User).WithMany(x => x.BootcampComments).HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Bootcamp).WithMany(x => x.BootcampComments).HasForeignKey(x => x.BootcampId);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("Blacklists").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Reason).HasColumnName("Reason");
        builder.Property(b => b.Date).HasColumnName("Date");
        builder.Property(b => b.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        //Relationships
        builder.HasOne(x => x.Applicant);

        //builder.HasOne<Applicant>(a => a.Applicant)
        //    .WithOne(b => b.Blacklist)
        //    .HasForeignKey<Blacklist>(a => a.ApplicantId);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}

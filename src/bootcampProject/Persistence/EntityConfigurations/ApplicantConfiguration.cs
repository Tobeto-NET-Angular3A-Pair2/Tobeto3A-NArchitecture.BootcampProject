using System.Reflection.Emit;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.ToTable("Applicants");

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserName).HasColumnName("UserName");
        builder.Property(a => a.About).HasColumnName("About");

        //Relationship
        builder.HasMany(x => x.Applications);
        builder.HasOne(x => x.Blacklist);

        //builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}

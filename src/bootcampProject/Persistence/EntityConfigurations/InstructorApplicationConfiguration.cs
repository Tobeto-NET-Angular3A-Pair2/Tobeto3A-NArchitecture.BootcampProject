using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InstructorApplicationConfiguration : IEntityTypeConfiguration<InstructorApplication>
{
    public void Configure(EntityTypeBuilder<InstructorApplication> builder)
    {
        builder.ToTable("InstructorApplications").HasKey(ia => ia.Id);

        builder.Property(ia => ia.Id).HasColumnName("Id").IsRequired();
        builder.Property(ia => ia.Email).HasColumnName("Email").IsRequired();
        builder.Property(ia => ia.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(ia => ia.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(ia => ia.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
        builder.Property(ia => ia.NationalIdentity).HasColumnName("NationalIdentity");
        builder.Property(ia => ia.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(ia => ia.AdditionalInformation).HasColumnName("AdditionalInformation").HasMaxLength(200);
        builder.Property(ia => ia.Comment).HasColumnName("Comment").HasMaxLength(100);
        builder.Property(ia => ia.IsApproved).HasColumnName("IsApproved");
        builder.Property(ia => ia.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ia => ia.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ia => ia.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ia => !ia.DeletedDate.HasValue);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable("Settings").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Title).HasColumnName("Title");
        builder.Property(s => s.Description).HasColumnName("Description");
        builder.Property(s => s.Keywords).HasColumnName("Keywords");
        builder.Property(s => s.Email).HasColumnName("Email");
        builder.Property(s => s.Phone).HasColumnName("Phone");
        builder.Property(s => s.GoogleSiteKey).HasColumnName("GoogleSiteKey");
        builder.Property(s => s.GoogleSecretKey).HasColumnName("GoogleSecretKey");
        builder.Property(s => s.GoogleAnalytics).HasColumnName("GoogleAnalytics");
        builder.Property(s => s.LogoUrl).HasColumnName("LogoUrl");
        builder.Property(s => s.FaviconUrl).HasColumnName("FaviconUrl");
        builder.Property(s => s.MaintenanceMode).HasColumnName("MaintenanceMode");
        builder.Property(s => s.TermsOfUse).HasColumnName("TermsOfUse");
        builder.Property(s => s.PrivacyPolicy).HasColumnName("PrivacyPolicy");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    private IEnumerable<Setting> _seeds
    {
        get
        {
            Setting setting =
                new()
                {
                    Id = 1,
                    Title = "Title",
                    Description = "Description",
                    Keywords = "Keywords",
                    Email = "Email",
                    Phone = "5555 555 55",
                    GoogleSiteKey = "",
                    GoogleSecretKey = "",
                    GoogleAnalytics = "",
                    LogoUrl = "",
                    FaviconUrl = "",
                    MaintenanceMode = false,
                    TermsOfUse = "",
                    PrivacyPolicy = "",
                    CreatedDate = DateTime.Now
                };
            yield return setting;
        }
    }
}
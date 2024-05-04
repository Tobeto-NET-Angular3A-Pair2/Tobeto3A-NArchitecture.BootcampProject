using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Setting : Entity<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Keywords { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? GoogleSiteKey { get; set; }
    public string? GoogleSecretKey { get; set; }
    public string? GoogleAnalytics { get; set; }
    public string LogoUrl { get; set; }
    public string FaviconUrl { get; set; }
    public Boolean MaintenanceMode { get; set; }
    public string TermsOfUse { get; set; }
    public string PrivacyPolicy { get; set; }

    public Setting(string? title, string? description, string? keywords, string? email, string? phone, string? googleSiteKey, string? googleSecretKey, string? googleAnalytics, string logoUrl, string faviconUrl, bool maintenanceMode, string termsOfUse, string privacyPolicy)
    {
        Title = title;
        Description = description;
        Keywords = keywords;
        Email = email;
        Phone = phone;
        GoogleSiteKey = googleSiteKey;
        GoogleSecretKey = googleSecretKey;
        GoogleAnalytics = googleAnalytics;
        LogoUrl = logoUrl;
        FaviconUrl = faviconUrl;
        MaintenanceMode = maintenanceMode;
        TermsOfUse = termsOfUse;
        PrivacyPolicy = privacyPolicy;
    }

    public Setting()
    {
    }
}

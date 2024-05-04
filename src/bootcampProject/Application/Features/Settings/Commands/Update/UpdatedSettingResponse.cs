using NArchitecture.Core.Application.Responses;

namespace Application.Features.Settings.Commands.Update;

public class UpdatedSettingResponse : IResponse
{
    public int Id { get; set; }
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
}
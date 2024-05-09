using Application.Common.Helpers;
using Application.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servicess;
public class EmailTemplateFillerManager : IEmailTemplateFillerService
{
    private readonly string _wwwrootPath;
    public EmailTemplateFillerManager(string wwwrootPath)
    {
        _wwwrootPath = wwwrootPath;
    }
    public string PopulateInstructorApplicationApproveEmail(string firstname, string lastname, string email, string password)
    {
        var htmlContent = File.ReadAllText($"{_wwwrootPath}/email_templates/email_instructor_application_information.html");

        htmlContent = htmlContent.Replace("{{name}}", MessagesHelper.Email.InstructorApplicationInfo.FullName(firstname,lastname));
        htmlContent = htmlContent.Replace("{{email}}", email);
        htmlContent = htmlContent.Replace("{{password}}", password);
        htmlContent = htmlContent.Replace("{{subject}}", MessagesHelper.Email.InstructorApplicationInfo.Subject);
        htmlContent = htmlContent.Replace("{{contactEmail}}", MessagesHelper.Email.InstructorApplicationInfo.ContactEmail);
        htmlContent = htmlContent.Replace("{{address}}", MessagesHelper.Email.InstructorApplicationInfo.Address);
        htmlContent = htmlContent.Replace("{{organizationLink}}", MessagesHelper.Email.InstructorApplicationInfo.OrganizationLink);


        return htmlContent;
    }
}

using Application.Features.Announcements.Constants;
using Application.Features.Applicants.Constants;
using Application.Features.ApplicationInformations.Constants;
using Application.Features.Auth.Constants;
using Application.Features.Blacklists.Constants;
using Application.Features.BootcampComments.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Contacts.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Evaluations.Constants;
using Application.Features.InstructorApplications.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.LessonContents.Constants;
using Application.Features.Lessons.Constants;
using Application.Features.Messages.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.Settings.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion



        #region Applicants
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Read },
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Write },
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Create },
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Update },
                new() { Id = ++lastId, Name = ApplicantsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Employees
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Read },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Write },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Create },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Update },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Instructors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Read },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Write },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Create },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Update },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Delete },
            ]
        );
        #endregion


        #region ApplicationInformations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Read },
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Write },
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Create },
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Update },
                new() { Id = ++lastId, Name = ApplicationInformationsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Blacklists
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Read },
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Write },
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Create },
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Update },
                new() { Id = ++lastId, Name = BlacklistsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Settings
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Delete },
            ]
        );
        #endregion




        #region Evaluations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Read },
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Write },
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Create },
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Update },
                new() { Id = ++lastId, Name = EvaluationsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Lessons
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LessonsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Read },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Write },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Create },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Update },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Delete },
            ]
        );
        #endregion


        #region LessonContents
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Read },
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Write },
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Create },
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Update },
                new() { Id = ++lastId, Name = LessonContentsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Bootcamps
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Read },
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Write },
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Create },
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Update },
                new() { Id = ++lastId, Name = BootcampsOperationClaims.Delete },
            ]
        );
        #endregion


        #region InstructorApplications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Read },
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Write },
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Create },
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Update },
                new() { Id = ++lastId, Name = InstructorApplicationsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Messages
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Announcements
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Read },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Write },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Create },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Update },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Contacts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ContactsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Read },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Write },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Create },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Update },
                new() { Id = ++lastId, Name = ContactsOperationClaims.Delete },
            ]
        );
        #endregion


        #region BootcampComments
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Read },
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Write },
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Create },
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Update },
                new() { Id = ++lastId, Name = BootcampCommentsOperationClaims.Delete },
            ]
        );
        #endregion

        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}

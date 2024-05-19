using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IBaseDbContext
{
    DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    DbSet<OperationClaim> OperationClaims { get; set; }
    DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    DbSet<RefreshToken> RefreshTokens { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    DbSet<Applicant> Applicants { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<Instructor> Instructors { get; set; }
    DbSet<ApplicationState> ApplicationStates { get; set; }
    DbSet<BootcampState> BootcampStates { get; set; }
    DbSet<ApplicationInformation> ApplicationInformations { get; set; }
    DbSet<Blacklist> Blacklists { get; set; }
    DbSet<Bootcamp> Bootcamps { get; set; }
    DbSet<InstructorApplication> InstructorApplications { get; set; }
    DbSet<Message> Messages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}

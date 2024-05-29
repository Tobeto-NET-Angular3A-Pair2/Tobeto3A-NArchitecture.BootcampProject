using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InstructorApplications;

public interface IInstructorApplicationService
{
    Task<InstructorApplication?> GetAsync(
        Expression<Func<InstructorApplication, bool>> predicate,
        Func<IQueryable<InstructorApplication>, IIncludableQueryable<InstructorApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<InstructorApplication>?> GetListAsync(
        Expression<Func<InstructorApplication, bool>>? predicate = null,
        Func<IQueryable<InstructorApplication>, IOrderedQueryable<InstructorApplication>>? orderBy = null,
        Func<IQueryable<InstructorApplication>, IIncludableQueryable<InstructorApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<InstructorApplication> AddAsync(InstructorApplication instructorApplication);
    Task<InstructorApplication> UpdateAsync(InstructorApplication instructorApplication);
    Task<InstructorApplication> DeleteAsync(InstructorApplication instructorApplication, bool permanent = false);
    Task<InstructorApplication> ApproveAsync(InstructorApplication instructorApplication);
}

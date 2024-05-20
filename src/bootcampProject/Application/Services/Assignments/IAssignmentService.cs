using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Assignments;

public interface IAssignmentService
{
    Task<Assignment?> GetAsync(
        Expression<Func<Assignment, bool>> predicate,
        Func<IQueryable<Assignment>, IIncludableQueryable<Assignment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Assignment>?> GetListAsync(
        Expression<Func<Assignment, bool>>? predicate = null,
        Func<IQueryable<Assignment>, IOrderedQueryable<Assignment>>? orderBy = null,
        Func<IQueryable<Assignment>, IIncludableQueryable<Assignment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Assignment> AddAsync(Assignment assignment);
    Task<Assignment> UpdateAsync(Assignment assignment);
    Task<Assignment> DeleteAsync(Assignment assignment, bool permanent = false);
}

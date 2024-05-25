using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.BootcampComments;

public interface IBootcampCommentService
{
    Task<BootcampComment?> GetAsync(
        Expression<Func<BootcampComment, bool>> predicate,
        Func<IQueryable<BootcampComment>, IIncludableQueryable<BootcampComment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BootcampComment>?> GetListAsync(
        Expression<Func<BootcampComment, bool>>? predicate = null,
        Func<IQueryable<BootcampComment>, IOrderedQueryable<BootcampComment>>? orderBy = null,
        Func<IQueryable<BootcampComment>, IIncludableQueryable<BootcampComment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BootcampComment> AddAsync(BootcampComment bootcampComment);
    Task<BootcampComment> UpdateAsync(BootcampComment bootcampComment);
    Task<BootcampComment> DeleteAsync(BootcampComment bootcampComment, bool permanent = false);
}

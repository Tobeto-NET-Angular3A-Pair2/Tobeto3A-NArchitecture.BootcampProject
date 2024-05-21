using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Evaluations;

public interface IEvaluationService
{
    Task<Evaluation?> GetAsync(
        Expression<Func<Evaluation, bool>> predicate,
        Func<IQueryable<Evaluation>, IIncludableQueryable<Evaluation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Evaluation>?> GetListAsync(
        Expression<Func<Evaluation, bool>>? predicate = null,
        Func<IQueryable<Evaluation>, IOrderedQueryable<Evaluation>>? orderBy = null,
        Func<IQueryable<Evaluation>, IIncludableQueryable<Evaluation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Evaluation> AddAsync(Evaluation evaluation);
    Task<Evaluation> UpdateAsync(Evaluation evaluation);
    Task<Evaluation> DeleteAsync(Evaluation evaluation, bool permanent = false);
}

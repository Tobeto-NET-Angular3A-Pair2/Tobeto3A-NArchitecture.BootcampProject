using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.MiniQuizs;

public interface IMiniQuizService
{
    Task<MiniQuiz?> GetAsync(
        Expression<Func<MiniQuiz, bool>> predicate,
        Func<IQueryable<MiniQuiz>, IIncludableQueryable<MiniQuiz, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MiniQuiz>?> GetListAsync(
        Expression<Func<MiniQuiz, bool>>? predicate = null,
        Func<IQueryable<MiniQuiz>, IOrderedQueryable<MiniQuiz>>? orderBy = null,
        Func<IQueryable<MiniQuiz>, IIncludableQueryable<MiniQuiz, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MiniQuiz> AddAsync(MiniQuiz miniQuiz);
    Task<MiniQuiz> UpdateAsync(MiniQuiz miniQuiz);
    Task<MiniQuiz> DeleteAsync(MiniQuiz miniQuiz, bool permanent = false);
}

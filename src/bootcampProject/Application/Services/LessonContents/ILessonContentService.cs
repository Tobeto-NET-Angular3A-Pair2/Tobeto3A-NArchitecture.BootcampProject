using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonContents;

public interface ILessonContentService
{
    Task<LessonContent?> GetAsync(
        Expression<Func<LessonContent, bool>> predicate,
        Func<IQueryable<LessonContent>, IIncludableQueryable<LessonContent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonContent>?> GetListAsync(
        Expression<Func<LessonContent, bool>>? predicate = null,
        Func<IQueryable<LessonContent>, IOrderedQueryable<LessonContent>>? orderBy = null,
        Func<IQueryable<LessonContent>, IIncludableQueryable<LessonContent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonContent> AddAsync(LessonContent lessonContent);
    Task<LessonContent> UpdateAsync(LessonContent lessonContent);
    Task<LessonContent> DeleteAsync(LessonContent lessonContent, bool permanent = false);
}

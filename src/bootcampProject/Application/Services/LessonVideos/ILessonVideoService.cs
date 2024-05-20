using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideos;

public interface ILessonVideoService
{
    Task<LessonVideo?> GetAsync(
        Expression<Func<LessonVideo, bool>> predicate,
        Func<IQueryable<LessonVideo>, IIncludableQueryable<LessonVideo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonVideo>?> GetListAsync(
        Expression<Func<LessonVideo, bool>>? predicate = null,
        Func<IQueryable<LessonVideo>, IOrderedQueryable<LessonVideo>>? orderBy = null,
        Func<IQueryable<LessonVideo>, IIncludableQueryable<LessonVideo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonVideo> AddAsync(LessonVideo lessonVideo);
    Task<LessonVideo> UpdateAsync(LessonVideo lessonVideo);
    Task<LessonVideo> DeleteAsync(LessonVideo lessonVideo, bool permanent = false);
}

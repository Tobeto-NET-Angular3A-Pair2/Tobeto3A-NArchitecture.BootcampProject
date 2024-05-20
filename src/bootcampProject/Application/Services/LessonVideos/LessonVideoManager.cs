using Application.Features.LessonVideos.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonVideos;

public class LessonVideoManager : ILessonVideoService
{
    private readonly ILessonVideoRepository _lessonVideoRepository;
    private readonly LessonVideoBusinessRules _lessonVideoBusinessRules;

    public LessonVideoManager(ILessonVideoRepository lessonVideoRepository, LessonVideoBusinessRules lessonVideoBusinessRules)
    {
        _lessonVideoRepository = lessonVideoRepository;
        _lessonVideoBusinessRules = lessonVideoBusinessRules;
    }

    public async Task<LessonVideo?> GetAsync(
        Expression<Func<LessonVideo, bool>> predicate,
        Func<IQueryable<LessonVideo>, IIncludableQueryable<LessonVideo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonVideo? lessonVideo = await _lessonVideoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonVideo;
    }

    public async Task<IPaginate<LessonVideo>?> GetListAsync(
        Expression<Func<LessonVideo, bool>>? predicate = null,
        Func<IQueryable<LessonVideo>, IOrderedQueryable<LessonVideo>>? orderBy = null,
        Func<IQueryable<LessonVideo>, IIncludableQueryable<LessonVideo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonVideo> lessonVideoList = await _lessonVideoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonVideoList;
    }

    public async Task<LessonVideo> AddAsync(LessonVideo lessonVideo)
    {
        LessonVideo addedLessonVideo = await _lessonVideoRepository.AddAsync(lessonVideo);

        return addedLessonVideo;
    }

    public async Task<LessonVideo> UpdateAsync(LessonVideo lessonVideo)
    {
        LessonVideo updatedLessonVideo = await _lessonVideoRepository.UpdateAsync(lessonVideo);

        return updatedLessonVideo;
    }

    public async Task<LessonVideo> DeleteAsync(LessonVideo lessonVideo, bool permanent = false)
    {
        LessonVideo deletedLessonVideo = await _lessonVideoRepository.DeleteAsync(lessonVideo);

        return deletedLessonVideo;
    }
}

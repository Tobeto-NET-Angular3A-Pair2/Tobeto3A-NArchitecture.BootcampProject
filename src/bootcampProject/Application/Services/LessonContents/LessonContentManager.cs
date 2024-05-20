using Application.Features.LessonContents.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonContents;

public class LessonContentManager : ILessonContentService
{
    private readonly ILessonContentRepository _lessonContentRepository;
    private readonly LessonContentBusinessRules _lessonContentBusinessRules;

    public LessonContentManager(ILessonContentRepository lessonContentRepository, LessonContentBusinessRules lessonContentBusinessRules)
    {
        _lessonContentRepository = lessonContentRepository;
        _lessonContentBusinessRules = lessonContentBusinessRules;
    }

    public async Task<LessonContent?> GetAsync(
        Expression<Func<LessonContent, bool>> predicate,
        Func<IQueryable<LessonContent>, IIncludableQueryable<LessonContent, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonContent? lessonContent = await _lessonContentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonContent;
    }

    public async Task<IPaginate<LessonContent>?> GetListAsync(
        Expression<Func<LessonContent, bool>>? predicate = null,
        Func<IQueryable<LessonContent>, IOrderedQueryable<LessonContent>>? orderBy = null,
        Func<IQueryable<LessonContent>, IIncludableQueryable<LessonContent, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonContent> lessonContentList = await _lessonContentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonContentList;
    }

    public async Task<LessonContent> AddAsync(LessonContent lessonContent)
    {
        LessonContent addedLessonContent = await _lessonContentRepository.AddAsync(lessonContent);

        return addedLessonContent;
    }

    public async Task<LessonContent> UpdateAsync(LessonContent lessonContent)
    {
        LessonContent updatedLessonContent = await _lessonContentRepository.UpdateAsync(lessonContent);

        return updatedLessonContent;
    }

    public async Task<LessonContent> DeleteAsync(LessonContent lessonContent, bool permanent = false)
    {
        LessonContent deletedLessonContent = await _lessonContentRepository.DeleteAsync(lessonContent);

        return deletedLessonContent;
    }
}

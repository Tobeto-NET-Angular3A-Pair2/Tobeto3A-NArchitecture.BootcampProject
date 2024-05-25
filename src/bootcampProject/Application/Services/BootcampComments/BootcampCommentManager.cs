using Application.Features.BootcampComments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BootcampComments;

public class BootcampCommentManager : IBootcampCommentService
{
    private readonly IBootcampCommentRepository _bootcampCommentRepository;
    private readonly BootcampCommentBusinessRules _bootcampCommentBusinessRules;

    public BootcampCommentManager(IBootcampCommentRepository bootcampCommentRepository, BootcampCommentBusinessRules bootcampCommentBusinessRules)
    {
        _bootcampCommentRepository = bootcampCommentRepository;
        _bootcampCommentBusinessRules = bootcampCommentBusinessRules;
    }

    public async Task<BootcampComment?> GetAsync(
        Expression<Func<BootcampComment, bool>> predicate,
        Func<IQueryable<BootcampComment>, IIncludableQueryable<BootcampComment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BootcampComment? bootcampComment = await _bootcampCommentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bootcampComment;
    }

    public async Task<IPaginate<BootcampComment>?> GetListAsync(
        Expression<Func<BootcampComment, bool>>? predicate = null,
        Func<IQueryable<BootcampComment>, IOrderedQueryable<BootcampComment>>? orderBy = null,
        Func<IQueryable<BootcampComment>, IIncludableQueryable<BootcampComment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BootcampComment> bootcampCommentList = await _bootcampCommentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampCommentList;
    }

    public async Task<BootcampComment> AddAsync(BootcampComment bootcampComment)
    {
        BootcampComment addedBootcampComment = await _bootcampCommentRepository.AddAsync(bootcampComment);

        return addedBootcampComment;
    }

    public async Task<BootcampComment> UpdateAsync(BootcampComment bootcampComment)
    {
        BootcampComment updatedBootcampComment = await _bootcampCommentRepository.UpdateAsync(bootcampComment);

        return updatedBootcampComment;
    }

    public async Task<BootcampComment> DeleteAsync(BootcampComment bootcampComment, bool permanent = false)
    {
        BootcampComment deletedBootcampComment = await _bootcampCommentRepository.DeleteAsync(bootcampComment);

        return deletedBootcampComment;
    }
}

using Application.Features.MiniQuizs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MiniQuizs;

public class MiniQuizManager : IMiniQuizService
{
    private readonly IMiniQuizRepository _miniQuizRepository;
    private readonly MiniQuizBusinessRules _miniQuizBusinessRules;

    public MiniQuizManager(IMiniQuizRepository miniQuizRepository, MiniQuizBusinessRules miniQuizBusinessRules)
    {
        _miniQuizRepository = miniQuizRepository;
        _miniQuizBusinessRules = miniQuizBusinessRules;
    }

    public async Task<MiniQuiz?> GetAsync(
        Expression<Func<MiniQuiz, bool>> predicate,
        Func<IQueryable<MiniQuiz>, IIncludableQueryable<MiniQuiz, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MiniQuiz? miniQuiz = await _miniQuizRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return miniQuiz;
    }

    public async Task<IPaginate<MiniQuiz>?> GetListAsync(
        Expression<Func<MiniQuiz, bool>>? predicate = null,
        Func<IQueryable<MiniQuiz>, IOrderedQueryable<MiniQuiz>>? orderBy = null,
        Func<IQueryable<MiniQuiz>, IIncludableQueryable<MiniQuiz, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MiniQuiz> miniQuizList = await _miniQuizRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return miniQuizList;
    }

    public async Task<MiniQuiz> AddAsync(MiniQuiz miniQuiz)
    {
        MiniQuiz addedMiniQuiz = await _miniQuizRepository.AddAsync(miniQuiz);

        return addedMiniQuiz;
    }

    public async Task<MiniQuiz> UpdateAsync(MiniQuiz miniQuiz)
    {
        MiniQuiz updatedMiniQuiz = await _miniQuizRepository.UpdateAsync(miniQuiz);

        return updatedMiniQuiz;
    }

    public async Task<MiniQuiz> DeleteAsync(MiniQuiz miniQuiz, bool permanent = false)
    {
        MiniQuiz deletedMiniQuiz = await _miniQuizRepository.DeleteAsync(miniQuiz);

        return deletedMiniQuiz;
    }
}

using System.Linq.Expressions;
using Application.Features.Evaluations.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Evaluations;

public class EvaluationManager : IEvaluationService
{
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly EvaluationBusinessRules _evaluationBusinessRules;

    public EvaluationManager(IEvaluationRepository evaluationRepository, EvaluationBusinessRules evaluationBusinessRules)
    {
        _evaluationRepository = evaluationRepository;
        _evaluationBusinessRules = evaluationBusinessRules;
    }

    public async Task<Evaluation?> GetAsync(
        Expression<Func<Evaluation, bool>> predicate,
        Func<IQueryable<Evaluation>, IIncludableQueryable<Evaluation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Evaluation? evaluation = await _evaluationRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return evaluation;
    }

    public async Task<IPaginate<Evaluation>?> GetListAsync(
        Expression<Func<Evaluation, bool>>? predicate = null,
        Func<IQueryable<Evaluation>, IOrderedQueryable<Evaluation>>? orderBy = null,
        Func<IQueryable<Evaluation>, IIncludableQueryable<Evaluation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Evaluation> evaluationList = await _evaluationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return evaluationList;
    }

    public async Task<Evaluation> AddAsync(Evaluation evaluation)
    {
        Evaluation addedEvaluation = await _evaluationRepository.AddAsync(evaluation);

        return addedEvaluation;
    }

    public async Task<Evaluation> UpdateAsync(Evaluation evaluation)
    {
        Evaluation updatedEvaluation = await _evaluationRepository.UpdateAsync(evaluation);

        return updatedEvaluation;
    }

    public async Task<Evaluation> DeleteAsync(Evaluation evaluation, bool permanent = false)
    {
        Evaluation deletedEvaluation = await _evaluationRepository.DeleteAsync(evaluation);

        return deletedEvaluation;
    }
}

using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EvaluationRepository : EfRepositoryBase<Evaluation, int, BaseDbContext>, IEvaluationRepository
{
    public EvaluationRepository(BaseDbContext context) : base(context)
    {
    }
}
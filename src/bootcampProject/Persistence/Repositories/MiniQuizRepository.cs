using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MiniQuizRepository : EfRepositoryBase<MiniQuiz, int, BaseDbContext>, IMiniQuizRepository
{
    public MiniQuizRepository(BaseDbContext context)
        : base(context) { }
}

using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonVideoRepository : EfRepositoryBase<LessonVideo, int, BaseDbContext>, ILessonVideoRepository
{
    public LessonVideoRepository(BaseDbContext context)
        : base(context) { }
}

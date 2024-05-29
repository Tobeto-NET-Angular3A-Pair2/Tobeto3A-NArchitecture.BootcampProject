using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonContentRepository : EfRepositoryBase<LessonContent, int, BaseDbContext>, ILessonContentRepository
{
    public LessonContentRepository(BaseDbContext context)
        : base(context) { }
}

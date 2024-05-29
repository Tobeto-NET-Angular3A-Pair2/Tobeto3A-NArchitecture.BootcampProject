using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BootcampCommentRepository : EfRepositoryBase<BootcampComment, int, BaseDbContext>, IBootcampCommentRepository
{
    public BootcampCommentRepository(BaseDbContext context)
        : base(context) { }
}

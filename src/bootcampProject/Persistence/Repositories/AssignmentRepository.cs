using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AssignmentRepository : EfRepositoryBase<Assignment, int, BaseDbContext>, IAssignmentRepository
{
    public AssignmentRepository(BaseDbContext context) : base(context)
    {
    }
}
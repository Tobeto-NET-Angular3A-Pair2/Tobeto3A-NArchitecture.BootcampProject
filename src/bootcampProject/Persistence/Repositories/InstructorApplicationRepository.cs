using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InstructorApplicationRepository : EfRepositoryBase<InstructorApplication, int, BaseDbContext>, IInstructorApplicationRepository
{
    public InstructorApplicationRepository(BaseDbContext context) : base(context)
    {
    }
}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAssignmentRepository : IAsyncRepository<Assignment, int>, IRepository<Assignment, int> { }

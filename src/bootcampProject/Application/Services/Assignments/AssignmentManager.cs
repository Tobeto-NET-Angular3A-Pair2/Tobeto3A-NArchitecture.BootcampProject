using System.Linq.Expressions;
using Application.Features.Assignments.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Assignments;

public class AssignmentManager : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly AssignmentBusinessRules _assignmentBusinessRules;

    public AssignmentManager(IAssignmentRepository assignmentRepository, AssignmentBusinessRules assignmentBusinessRules)
    {
        _assignmentRepository = assignmentRepository;
        _assignmentBusinessRules = assignmentBusinessRules;
    }

    public async Task<Assignment?> GetAsync(
        Expression<Func<Assignment, bool>> predicate,
        Func<IQueryable<Assignment>, IIncludableQueryable<Assignment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Assignment? assignment = await _assignmentRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return assignment;
    }

    public async Task<IPaginate<Assignment>?> GetListAsync(
        Expression<Func<Assignment, bool>>? predicate = null,
        Func<IQueryable<Assignment>, IOrderedQueryable<Assignment>>? orderBy = null,
        Func<IQueryable<Assignment>, IIncludableQueryable<Assignment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Assignment> assignmentList = await _assignmentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return assignmentList;
    }

    public async Task<Assignment> AddAsync(Assignment assignment)
    {
        Assignment addedAssignment = await _assignmentRepository.AddAsync(assignment);

        return addedAssignment;
    }

    public async Task<Assignment> UpdateAsync(Assignment assignment)
    {
        Assignment updatedAssignment = await _assignmentRepository.UpdateAsync(assignment);

        return updatedAssignment;
    }

    public async Task<Assignment> DeleteAsync(Assignment assignment, bool permanent = false)
    {
        Assignment deletedAssignment = await _assignmentRepository.DeleteAsync(assignment);

        return deletedAssignment;
    }
}

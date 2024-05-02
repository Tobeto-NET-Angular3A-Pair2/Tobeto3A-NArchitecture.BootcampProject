using Application.Features.InstructorApplications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InstructorApplications;

public class InstructorApplicationManager : IInstructorApplicationService
{
    private readonly IInstructorApplicationRepository _instructorApplicationRepository;
    private readonly InstructorApplicationBusinessRules _instructorApplicationBusinessRules;

    public InstructorApplicationManager(IInstructorApplicationRepository instructorApplicationRepository, InstructorApplicationBusinessRules instructorApplicationBusinessRules)
    {
        _instructorApplicationRepository = instructorApplicationRepository;
        _instructorApplicationBusinessRules = instructorApplicationBusinessRules;
    }

    public async Task<InstructorApplication?> GetAsync(
        Expression<Func<InstructorApplication, bool>> predicate,
        Func<IQueryable<InstructorApplication>, IIncludableQueryable<InstructorApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        InstructorApplication? instructorApplication = await _instructorApplicationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return instructorApplication;
    }

    public async Task<IPaginate<InstructorApplication>?> GetListAsync(
        Expression<Func<InstructorApplication, bool>>? predicate = null,
        Func<IQueryable<InstructorApplication>, IOrderedQueryable<InstructorApplication>>? orderBy = null,
        Func<IQueryable<InstructorApplication>, IIncludableQueryable<InstructorApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<InstructorApplication> instructorApplicationList = await _instructorApplicationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return instructorApplicationList;
    }

    public async Task<InstructorApplication> AddAsync(InstructorApplication instructorApplication)
    {
        InstructorApplication addedInstructorApplication = await _instructorApplicationRepository.AddAsync(instructorApplication);

        return addedInstructorApplication;
    }

    public async Task<InstructorApplication> UpdateAsync(InstructorApplication instructorApplication)
    {
        InstructorApplication updatedInstructorApplication = await _instructorApplicationRepository.UpdateAsync(instructorApplication);

        return updatedInstructorApplication;
    }

    public async Task<InstructorApplication> DeleteAsync(InstructorApplication instructorApplication, bool permanent = false)
    {
        InstructorApplication deletedInstructorApplication = await _instructorApplicationRepository.DeleteAsync(instructorApplication);

        return deletedInstructorApplication;
    }

    public async Task<InstructorApplication> ApproveAsync(InstructorApplication instructorApplication)
    {
        InstructorApplication approvedInstructorApplication = await _instructorApplicationRepository.UpdateAsync(instructorApplication);
        
        return approvedInstructorApplication;
    }
}

using Application.Features.Assignments.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Assignments.Rules;

public class AssignmentBusinessRules : BaseBusinessRules
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ILocalizationService _localizationService;

    public AssignmentBusinessRules(IAssignmentRepository assignmentRepository, ILocalizationService localizationService)
    {
        _assignmentRepository = assignmentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AssignmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AssignmentShouldExistWhenSelected(Assignment? assignment)
    {
        if (assignment == null)
            await throwBusinessException(AssignmentsBusinessMessages.AssignmentNotExists);
    }

    public async Task AssignmentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Assignment? assignment = await _assignmentRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AssignmentShouldExistWhenSelected(assignment);
    }
}

using FluentValidation;

namespace Application.Features.InstructorApplications.Commands.Update;

public class UpdateInstructorApplicationCommandValidator : AbstractValidator<UpdateInstructorApplicationCommand>
{
    public UpdateInstructorApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.AdditionalInformation).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.IsApproved).NotEmpty();
    }
}
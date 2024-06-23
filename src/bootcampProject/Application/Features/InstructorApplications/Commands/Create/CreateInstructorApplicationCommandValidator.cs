using FluentValidation;

namespace Application.Features.InstructorApplications.Commands.Create;

public class CreateInstructorApplicationCommandValidator : AbstractValidator<CreateInstructorApplicationCommand>
{
    public CreateInstructorApplicationCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.AdditionalInformation).MaximumLength(200);
    }
}

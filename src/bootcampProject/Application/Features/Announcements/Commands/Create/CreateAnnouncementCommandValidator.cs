using FluentValidation;

namespace Application.Features.Announcements.Commands.Create;

public class CreateAnnouncementCommandValidator : AbstractValidator<CreateAnnouncementCommand>
{
    public CreateAnnouncementCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Content).NotEmpty().MaximumLength(250);
        RuleFor(c => c.InstructorId).NotEmpty();
    }
}

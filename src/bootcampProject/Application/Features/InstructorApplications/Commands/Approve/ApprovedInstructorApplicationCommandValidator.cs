using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.InstructorApplications.Commands.Update;
using Application.Features.InstructorApplications.Constants;
using Application.Features.InstructorApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.InstructorApplications.Commands.Approve;

public class ApprovedInstructorApplicationCommandValidator : AbstractValidator<ApproveInstructorApplicationCommand>
{
    public ApprovedInstructorApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Comment).MaximumLength(100);
    }
}

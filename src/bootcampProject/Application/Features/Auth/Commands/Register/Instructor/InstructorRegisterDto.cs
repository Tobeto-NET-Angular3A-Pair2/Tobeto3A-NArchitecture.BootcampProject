﻿namespace Application.Features.Auth.Commands.Register.Instructor;

public class InstructorRegisterDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string CompanyName { get; set; }
}

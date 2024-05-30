using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InstructorApplications.Commands.Approve;

public class ApprovedInstructorApplicationResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Comment { get; set; }
    public bool? IsApproved { get; set; }
}

using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.RefreshToken;

public class InstructorRegisterCommand : IRequest<RegisteredResponse>
{
    public InstructorRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public InstructorRegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public InstructorRegisterCommand(InstructorRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<InstructorRegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IInstructorRepository ınstructorRepository,
            IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _instructorRepository = ınstructorRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RegisteredResponse> Handle(InstructorRegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            Instructor newUser =
                new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    NationalIdentity = request.UserForRegisterDto.NationalIdentity,
                    DateOfBirth = request.UserForRegisterDto.DateOfBirth,
                    CompanyName = request.UserForRegisterDto.CompanyName,
                    UserName = request.UserForRegisterDto.UserName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            Instructor createdUser = await _instructorRepository.AddAsync(newUser);

            UserOperationClaim userOperationClaim1 = new() { UserId = createdUser.Id, OperationClaimId = 36 };
            UserOperationClaim userOperationClaim2 = new() { UserId = createdUser.Id, OperationClaimId = 37 };

            await _userOperationClaimRepository.AddAsync(userOperationClaim1);
            await _userOperationClaimRepository.AddAsync(userOperationClaim2);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                createdUser,
                request.IpAddress
            );
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.RefreshToken;

public class ApplicantRegisterCommand : IRequest<RegisteredResponse>
{
    public ApplicantRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public ApplicantRegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public ApplicantRegisterCommand(ApplicantRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<ApplicantRegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
<<<<<<< HEAD
            IApplicantRepository applicantRepository,
            IUserOperationClaimRepository userOperationClaimRepository)
=======
            IApplicantRepository applicantRepository
        )
>>>>>>> efe93d8cb976260f7ea3ffd6ead0f90e47294978
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _applicantRepository = applicantRepository;
            _userOperationClaimRepository = userOperationClaimRepository;

        }

        public async Task<RegisteredResponse> Handle(ApplicantRegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            Applicant newUser =
                new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    NationalIdentity = request.UserForRegisterDto.NationalIdentity,
                    DateOfBirth = request.UserForRegisterDto.DateOfBirth,
                    About = request.UserForRegisterDto.About,
                    UserName = request.UserForRegisterDto.UserName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            Applicant createdUser = await _applicantRepository.AddAsync(newUser);

            UserOperationClaim userOperationClaim1 = new() { UserId = createdUser.Id, OperationClaimId = 24 };
            UserOperationClaim userOperationClaim2 = new() { UserId = createdUser.Id, OperationClaimId = 25 };

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

using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    //public UserForRegisterDto UserForRegisterDto { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        //UserForRegisterDto = null!;
        Email = string.Empty;
        Password = null;
        IpAddress = string.Empty;
        UserName = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        NationalIdentity = string.Empty;
    }

    //public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    //{
    //    UserForRegisterDto = userForRegisterDto;
    //    IpAddress = ipAddress;
    //}

    //public RegisterCommand(UserForRegisterDto userForRegisterDto, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string ipAddress)
    //{
    //    UserForRegisterDto = userForRegisterDto;
    //    UserName = userName;
    //    FirstName = firstName;
    //    LastName = lastName;
    //    DateOfBirth = dateOfBirth;
    //    NationalIdentity = nationalIdentity;
    //    IpAddress = ipAddress;
    //}
    public RegisterCommand(
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string ipAddress,
        string email = null,
        string password = null
    )
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        IpAddress = ipAddress;
        Email = email;
        Password = password;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules
        )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
            await _authBusinessRules.UserEmailShouldBeNotExists(request.Email);

            HashingHelper.CreatePasswordHash(
                //request.UserForRegisterDto.Password,
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    //Email = request.UserForRegisterDto.Email,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    NationalIdentity = request.NationalIdentity,
                };

            User createdUser = await _userRepository.AddAsync(newUser);

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

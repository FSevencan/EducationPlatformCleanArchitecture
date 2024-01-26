using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.Students;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;


namespace Application.Features.Auth.Commands.StudentRegister;
public class StudentRegisterCommand : IRequest<StudentRegisteredResponse>
{
    public StudentForRegisterDto StudentForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public StudentRegisterCommand()
    {
        StudentForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public StudentRegisterCommand(StudentForRegisterDto studentForRegisterDto, string ipAddress)
    {
        StudentForRegisterDto = studentForRegisterDto;
        IpAddress = ipAddress;
    }



    public class StudentRegisterCommandHandler : IRequestHandler<StudentRegisterCommand, StudentRegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentsService _studentsService;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public StudentRegisterCommandHandler(IUserRepository userRepository, IStudentsService studentsService, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _studentsService = studentsService;
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<StudentRegisteredResponse> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
        {
            // Öğrenci e-postası kontrolü
            await _authBusinessRules.StudentEmailShouldBeNotExists(request.StudentForRegisterDto.Email);

            // Şifre hashleme işlemi
            HashingHelper.CreatePasswordHash(
                request.StudentForRegisterDto.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );

            // Yeni kullanıcı nesnesi oluşturma
            User newUser = new User
            {
                Email = request.StudentForRegisterDto.Email,
                FirstName = request.StudentForRegisterDto.FirstName,
                LastName = request.StudentForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            // Kullanıcıyı veritabanına ekleme
            User createdUser = await _userRepository.AddAsync(newUser);

            // Yeni öğrenci nesnesi oluşturma
            Student newStudent = new Student
            {
                UserId = createdUser.Id,
               ImageUrl = "https://i.imgur.com/6pI4RCr.png"
            };

            // Öğrenciyi veritabanına ekleme
            await _studentsService.AddAsync(newStudent);

            // Kullanıcı için AccessToken oluşturma
            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            // Kullanıcı için RefreshToken oluşturma
            var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            // Student yetkisini bulma
            OperationClaim studentClaim = await _operationClaimRepository.GetAsync(c => c.Name == "Student");

            // Eğer Student yetkisi bulunamazsa bir hata fırlat
            if (studentClaim == null)
            {
                throw new Exception("Student yetkisi bulunamadı.");
            }

            // UserOperationClaim nesnesini oluştur ve veritabanına kaydet
            UserOperationClaim userOperationClaim = new UserOperationClaim(createdUser.Id, studentClaim.Id);
            await _userOperationClaimRepository.AddAsync(userOperationClaim);


            // Yanıt nesnesini oluşturma ve dönme
            StudentRegisteredResponse studentRegisteredResponse = new StudentRegisteredResponse
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };

            return studentRegisteredResponse;
        }

    }
}

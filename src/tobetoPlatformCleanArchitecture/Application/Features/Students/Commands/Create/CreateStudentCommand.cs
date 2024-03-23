using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Core.Security.Entities;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedinUrl { get; set; }
   

    public string[] Roles => new[] { Admin, Write, StudentsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudents";

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _mapper.Map<Student>(request);

            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);
            return response;
        }
    }
}
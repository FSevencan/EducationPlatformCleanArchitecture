using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.StudentLessons.Commands.Create;

public class CreateStudentLessonCommand : IRequest<CreatedStudentLessonResponse>
{
    public int UserId { get; set; }
    public Guid LessonId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsCompleted { get; set; }
   

    public class CreateStudentLessonCommandHandler : IRequestHandler<CreateStudentLessonCommand, CreatedStudentLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateStudentLessonCommandHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository,IHttpContextAccessor httpContextAccessor,
                                         IStudentRepository studentRepository, StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
            _httpContextAccessor = httpContextAccessor;
            _studentRepository = studentRepository;
        }

        public async Task<CreatedStudentLessonResponse> Handle(CreateStudentLessonCommand request, CancellationToken cancellationToken)
        {
            Student student = await _studentLessonBusinessRules.CheckIfStudentExists(request.UserId, cancellationToken);

            // Ayný ders için öðrenciye ait kaydýn olup olmadýðý kontrolü
            var existingLesson = await _studentLessonBusinessRules.CheckIfLessonRecordExistsForStudent(student.Id, request.LessonId, cancellationToken);

            if (existingLesson != null)
            {
                // Eðer kayýt varsa ve tamamlanmamýþsa, mevcut kaydýn detaylarýný döndür
                if (!existingLesson.IsCompleted)
                {
                    return new CreatedStudentLessonResponse
                    {
                        Id = existingLesson.Id,
                        StudentId = existingLesson.StudentId,
                        LessonId = existingLesson.LessonId,
                        StartTime = existingLesson.StartTime,
                        EndTime = existingLesson.EndTime,
                        IsCompleted = existingLesson.IsCompleted
                    };
                }
                else
                {
                    // Kayýt varsa ve tamamlanmýþsa, boþ bir yanýt döndür
                    return new CreatedStudentLessonResponse();
                }
            }

            StudentLesson studentLesson = _mapper.Map<StudentLesson>(request);
            studentLesson.StudentId = student.Id;
            await _studentLessonRepository.AddAsync(studentLesson);

            
            CreatedStudentLessonResponse response = _mapper.Map<CreatedStudentLessonResponse>(studentLesson);
            return response;
        }
        
    }
}
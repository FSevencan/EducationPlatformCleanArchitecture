using Application.Features.StudentLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentLessons.Rules;

public class StudentLessonBusinessRules : BaseBusinessRules
{
    private readonly IStudentLessonRepository _studentLessonRepository;
    private readonly IStudentRepository _studentRepository;
    public StudentLessonBusinessRules(IStudentLessonRepository studentLessonRepository, IStudentRepository studentRepository)
    {
        _studentLessonRepository = studentLessonRepository;
        _studentRepository = studentRepository;
    }

    public Task StudentLessonShouldExistWhenSelected(StudentLesson? studentLesson)
    {
        if (studentLesson == null)
            throw new BusinessException(StudentLessonsBusinessMessages.StudentLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentLessonIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(
            predicate: sl => sl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentLessonShouldExistWhenSelected(studentLesson);
    }


    public async Task<Student> CheckIfStudentExists(int userId, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(u => u.UserId == userId, cancellationToken: cancellationToken);
        if (student == null)
        {
            throw new NotFoundException("Öðrenci bulunamadý.");
        }
        return student;
    }


    public async Task<StudentLesson?> CheckIfLessonRecordExistsForStudent(int studentId, Guid lessonId, CancellationToken cancellationToken)
    {
        // Öðrenci için belirli bir ders kaydýný kontrol et
        StudentLesson? existingRecord = await _studentLessonRepository.GetAsync(
            sl => sl.StudentId == studentId && sl.LessonId == lessonId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

       
        return existingRecord;
    }
}
using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentLessons;

public class StudentLessonsManager : IStudentLessonsService
{
    private readonly IStudentLessonRepository _studentLessonRepository;
    private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

    public StudentLessonsManager(IStudentLessonRepository studentLessonRepository, StudentLessonBusinessRules studentLessonBusinessRules)
    {
        _studentLessonRepository = studentLessonRepository;
        _studentLessonBusinessRules = studentLessonBusinessRules;
    }

    public async Task<StudentLesson?> GetAsync(
        Expression<Func<StudentLesson, bool>> predicate,
        Func<IQueryable<StudentLesson>, IIncludableQueryable<StudentLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentLesson;
    }

    public async Task<IPaginate<StudentLesson>?> GetListAsync(
        Expression<Func<StudentLesson, bool>>? predicate = null,
        Func<IQueryable<StudentLesson>, IOrderedQueryable<StudentLesson>>? orderBy = null,
        Func<IQueryable<StudentLesson>, IIncludableQueryable<StudentLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentLesson> studentLessonList = await _studentLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentLessonList;
    }

    public async Task<StudentLesson> AddAsync(StudentLesson studentLesson)
    {
        StudentLesson addedStudentLesson = await _studentLessonRepository.AddAsync(studentLesson);

        return addedStudentLesson;
    }

    public async Task<StudentLesson> UpdateAsync(StudentLesson studentLesson)
    {
        StudentLesson updatedStudentLesson = await _studentLessonRepository.UpdateAsync(studentLesson);

        return updatedStudentLesson;
    }

    public async Task<StudentLesson> DeleteAsync(StudentLesson studentLesson, bool permanent = false)
    {
        StudentLesson deletedStudentLesson = await _studentLessonRepository.DeleteAsync(studentLesson);

        return deletedStudentLesson;
    }
}

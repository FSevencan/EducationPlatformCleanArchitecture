using Application.Features.Students.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Students;

public class StudentsManager : IStudentsService
{
    private readonly IStudentRepository _studentRepository;
    private readonly StudentBusinessRules _studentBusinessRules;

    public StudentsManager(IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
    {
        _studentRepository = studentRepository;
        _studentBusinessRules = studentBusinessRules;
    }

    public async Task<Student?> GetAsync(
        Expression<Func<Student, bool>> predicate,
        Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Student? student = await _studentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return student;
    }

    public async Task<IPaginate<Student>?> GetListAsync(
        Expression<Func<Student, bool>>? predicate = null,
        Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null,
        Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Student> studentList = await _studentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentList;
    }

    public async Task<Student> AddAsync(Student student)
    {
        Student addedStudent = await _studentRepository.AddAsync(student);

        return addedStudent;
    }

    public async Task<Student> UpdateAsync(Student student)
    {
        Student updatedStudent = await _studentRepository.UpdateAsync(student);

        return updatedStudent;
    }

    public async Task<Student> DeleteAsync(Student student, bool permanent = false)
    {
        Student deletedStudent = await _studentRepository.DeleteAsync(student);

        return deletedStudent;
    }
}

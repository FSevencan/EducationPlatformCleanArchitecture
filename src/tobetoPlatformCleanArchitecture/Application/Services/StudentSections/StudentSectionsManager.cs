using Application.Features.StudentSections.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSections;

public class StudentSectionsManager : IStudentSectionsService
{
    private readonly IStudentSectionRepository _studentSectionRepository;
    private readonly StudentSectionBusinessRules _studentSectionBusinessRules;

    public StudentSectionsManager(IStudentSectionRepository studentSectionRepository, StudentSectionBusinessRules studentSectionBusinessRules)
    {
        _studentSectionRepository = studentSectionRepository;
        _studentSectionBusinessRules = studentSectionBusinessRules;
    }

    public async Task<StudentSection?> GetAsync(
        Expression<Func<StudentSection, bool>> predicate,
        Func<IQueryable<StudentSection>, IIncludableQueryable<StudentSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentSection? studentSection = await _studentSectionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentSection;
    }

    public async Task<IPaginate<StudentSection>?> GetListAsync(
        Expression<Func<StudentSection, bool>>? predicate = null,
        Func<IQueryable<StudentSection>, IOrderedQueryable<StudentSection>>? orderBy = null,
        Func<IQueryable<StudentSection>, IIncludableQueryable<StudentSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentSection> studentSectionList = await _studentSectionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentSectionList;
    }

    public async Task<StudentSection> AddAsync(StudentSection studentSection)
    {
        StudentSection addedStudentSection = await _studentSectionRepository.AddAsync(studentSection);

        return addedStudentSection;
    }

    public async Task<StudentSection> UpdateAsync(StudentSection studentSection)
    {
        StudentSection updatedStudentSection = await _studentSectionRepository.UpdateAsync(studentSection);

        return updatedStudentSection;
    }

    public async Task<StudentSection> DeleteAsync(StudentSection studentSection, bool permanent = false)
    {
        StudentSection deletedStudentSection = await _studentSectionRepository.DeleteAsync(studentSection);

        return deletedStudentSection;
    }
}

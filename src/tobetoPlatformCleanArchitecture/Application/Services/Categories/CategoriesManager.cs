using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Categories;

public class CategoriesManager : ICategoriesService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CategoriesManager(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<Category?> GetAsync(
        Expression<Func<Category, bool>> predicate,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Category? category = await _categoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return category;
    }

    public async Task<IPaginate<Category>?> GetListAsync(
        Expression<Func<Category, bool>>? predicate = null,
        Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Category> categoryList = await _categoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return categoryList;
    }

    public async Task<Category> AddAsync(Category category)
    {
        Category addedCategory = await _categoryRepository.AddAsync(category);

        return addedCategory;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        Category updatedCategory = await _categoryRepository.UpdateAsync(category);

        return updatedCategory;
    }

    public async Task<Category> DeleteAsync(Category category, bool permanent = false)
    {
        Category deletedCategory = await _categoryRepository.DeleteAsync(category);

        return deletedCategory;
    }
}

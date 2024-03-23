using Application.Features.Choices.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Choices;

public class ChoicesManager : IChoicesService
{
    private readonly IChoiceRepository _choiceRepository;
    private readonly ChoiceBusinessRules _choiceBusinessRules;

    public ChoicesManager(IChoiceRepository choiceRepository, ChoiceBusinessRules choiceBusinessRules)
    {
        _choiceRepository = choiceRepository;
        _choiceBusinessRules = choiceBusinessRules;
    }

    public async Task<Choice?> GetAsync(
        Expression<Func<Choice, bool>> predicate,
        Func<IQueryable<Choice>, IIncludableQueryable<Choice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Choice? choice = await _choiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return choice;
    }

    public async Task<IPaginate<Choice>?> GetListAsync(
        Expression<Func<Choice, bool>>? predicate = null,
        Func<IQueryable<Choice>, IOrderedQueryable<Choice>>? orderBy = null,
        Func<IQueryable<Choice>, IIncludableQueryable<Choice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Choice> choiceList = await _choiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return choiceList;
    }

    public async Task<Choice> AddAsync(Choice choice)
    {
        Choice addedChoice = await _choiceRepository.AddAsync(choice);

        return addedChoice;
    }

    public async Task<Choice> UpdateAsync(Choice choice)
    {
        Choice updatedChoice = await _choiceRepository.UpdateAsync(choice);

        return updatedChoice;
    }

    public async Task<Choice> DeleteAsync(Choice choice, bool permanent = false)
    {
        Choice deletedChoice = await _choiceRepository.DeleteAsync(choice);

        return deletedChoice;
    }
}

using Application.Features.Choices.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Choices.Rules;

public class ChoiceBusinessRules : BaseBusinessRules
{
    private readonly IChoiceRepository _choiceRepository;

    public ChoiceBusinessRules(IChoiceRepository choiceRepository)
    {
        _choiceRepository = choiceRepository;
    }

    public Task ChoiceShouldExistWhenSelected(Choice? choice)
    {
        if (choice == null)
            throw new BusinessException(ChoicesBusinessMessages.ChoiceNotExists);
        return Task.CompletedTask;
    }

    public async Task ChoiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Choice? choice = await _choiceRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ChoiceShouldExistWhenSelected(choice);
    }
}
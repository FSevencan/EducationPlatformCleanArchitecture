using Application.Features.Contacts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Contacts.Rules;

public class ContactBusinessRules : BaseBusinessRules
{
    private readonly IContactRepository _contactRepository;

    public ContactBusinessRules(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Task ContactShouldExistWhenSelected(Contact? contact)
    {
        if (contact == null)
            throw new BusinessException(ContactsBusinessMessages.ContactNotExists);
        return Task.CompletedTask;
    }

    public async Task ContactIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Contact? contact = await _contactRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ContactShouldExistWhenSelected(contact);
    }
}
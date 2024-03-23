using Application.Features.Contacts.Constants;
using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Contacts.Constants.ContactsOperationClaims;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommand : IRequest<UpdatedContactResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime? ReadDate { get; set; }

    public string[] Roles => new[] { Admin, Write, ContactsOperationClaims.Update };

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdatedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public UpdateContactCommandHandler(IMapper mapper, IContactRepository contactRepository,
                                         ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<UpdatedContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contactBusinessRules.ContactShouldExistWhenSelected(contact);
            contact = _mapper.Map(request, contact);

            await _contactRepository.UpdateAsync(contact!);

            UpdatedContactResponse response = _mapper.Map<UpdatedContactResponse>(contact);
            return response;
        }
    }
}
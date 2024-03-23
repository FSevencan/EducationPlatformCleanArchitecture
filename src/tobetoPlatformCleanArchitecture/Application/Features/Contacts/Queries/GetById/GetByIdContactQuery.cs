using Application.Features.Contacts.Constants;
using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Contacts.Constants.ContactsOperationClaims;

namespace Application.Features.Contacts.Queries.GetById;

public class GetByIdContactQuery : IRequest<GetByIdContactResponse>
{
    public Guid Id { get; set; }


    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public GetByIdContactQueryHandler(IMapper mapper, IContactRepository contactRepository, ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<GetByIdContactResponse> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contactBusinessRules.ContactShouldExistWhenSelected(contact);

            GetByIdContactResponse response = _mapper.Map<GetByIdContactResponse>(contact);
            return response;
        }
    }
}
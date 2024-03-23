using Application.Features.Choices.Constants;
using Application.Features.Choices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Choices.Constants.ChoicesOperationClaims;

namespace Application.Features.Choices.Queries.GetById;

public class GetByIdChoiceQuery : IRequest<GetByIdChoiceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdChoiceQueryHandler : IRequestHandler<GetByIdChoiceQuery, GetByIdChoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChoiceRepository _choiceRepository;
        private readonly ChoiceBusinessRules _choiceBusinessRules;

        public GetByIdChoiceQueryHandler(IMapper mapper, IChoiceRepository choiceRepository, ChoiceBusinessRules choiceBusinessRules)
        {
            _mapper = mapper;
            _choiceRepository = choiceRepository;
            _choiceBusinessRules = choiceBusinessRules;
        }

        public async Task<GetByIdChoiceResponse> Handle(GetByIdChoiceQuery request, CancellationToken cancellationToken)
        {
            Choice? choice = await _choiceRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _choiceBusinessRules.ChoiceShouldExistWhenSelected(choice);

            GetByIdChoiceResponse response = _mapper.Map<GetByIdChoiceResponse>(choice);
            return response;
        }
    }
}
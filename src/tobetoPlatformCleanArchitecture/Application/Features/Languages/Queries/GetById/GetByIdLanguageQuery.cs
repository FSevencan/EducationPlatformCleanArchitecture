using Application.Features.Languages.Constants;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Languages.Constants.LanguagesOperationClaims;

namespace Application.Features.Languages.Queries.GetById;

public class GetByIdLanguageQuery : IRequest<GetByIdLanguageResponse>
{
    public Guid Id { get; set; }



    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public GetByIdLanguageQueryHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<GetByIdLanguageResponse> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _languageBusinessRules.LanguageShouldExistWhenSelected(language);

            GetByIdLanguageResponse response = _mapper.Map<GetByIdLanguageResponse>(language);
            return response;
        }
    }
}
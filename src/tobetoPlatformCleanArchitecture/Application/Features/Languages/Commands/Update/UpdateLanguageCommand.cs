using Application.Features.Languages.Constants;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Languages.Constants.LanguagesOperationClaims;

namespace Application.Features.Languages.Commands.Update;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, LanguagesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLanguages";

    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public UpdateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository,
                                         LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<UpdatedLanguageResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _languageBusinessRules.LanguageShouldExistWhenSelected(language);
            language = _mapper.Map(request, language);

            await _languageRepository.UpdateAsync(language!);

            UpdatedLanguageResponse response = _mapper.Map<UpdatedLanguageResponse>(language);
            return response;
        }
    }
}
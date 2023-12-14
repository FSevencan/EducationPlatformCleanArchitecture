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

namespace Application.Features.Languages.Commands.Create;

public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, LanguagesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLanguages";

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository,
                                         LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language language = _mapper.Map<Language>(request);

            await _languageRepository.AddAsync(language);

            CreatedLanguageResponse response = _mapper.Map<CreatedLanguageResponse>(language);
            return response;
        }
    }
}
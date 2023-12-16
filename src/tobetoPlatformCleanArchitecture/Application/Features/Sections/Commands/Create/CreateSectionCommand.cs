using Application.Features.Sections.Constants;
using Application.Features.Sections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sections.Constants.SectionsOperationClaims;

namespace Application.Features.Sections.Commands.Create;

public class CreateSectionCommand : IRequest<CreatedSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSections";

    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, CreatedSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionBusinessRules _sectionBusinessRules;

        public CreateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository,
                                         SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<CreatedSectionResponse> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            Section section = _mapper.Map<Section>(request);

            await _sectionRepository.AddAsync(section);

            CreatedSectionResponse response = _mapper.Map<CreatedSectionResponse>(section);
            return response;
        }
    }
}
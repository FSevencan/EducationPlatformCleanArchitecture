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

namespace Application.Features.Sections.Commands.Update;

public class UpdateSectionCommand : IRequest<UpdatedSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SectionAboutId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSections";

    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, UpdatedSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionBusinessRules _sectionBusinessRules;

        public UpdateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository,
                                         SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<UpdatedSectionResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            Section? section = await _sectionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionBusinessRules.SectionShouldExistWhenSelected(section);
            section = _mapper.Map(request, section);

            await _sectionRepository.UpdateAsync(section!);

            UpdatedSectionResponse response = _mapper.Map<UpdatedSectionResponse>(section);
            return response;
        }
    }
}
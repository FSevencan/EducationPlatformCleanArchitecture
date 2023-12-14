using Application.Features.Sections.Constants;
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

namespace Application.Features.Sections.Commands.Delete;

public class DeleteSectionCommand : IRequest<DeletedSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSections";

    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, DeletedSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionBusinessRules _sectionBusinessRules;

        public DeleteSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository,
                                         SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<DeletedSectionResponse> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            Section? section = await _sectionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionBusinessRules.SectionShouldExistWhenSelected(section);

            await _sectionRepository.DeleteAsync(section!);

            DeletedSectionResponse response = _mapper.Map<DeletedSectionResponse>(section);
            return response;
        }
    }
}
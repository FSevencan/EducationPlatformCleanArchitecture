using Application.Features.Sections.Constants;
using Application.Features.Sections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sections.Constants.SectionsOperationClaims;

namespace Application.Features.Sections.Queries.GetById;

public class GetByIdSectionQuery : IRequest<GetByIdSectionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSectionQueryHandler : IRequestHandler<GetByIdSectionQuery, GetByIdSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionBusinessRules _sectionBusinessRules;

        public GetByIdSectionQueryHandler(IMapper mapper, ISectionRepository sectionRepository, SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<GetByIdSectionResponse> Handle(GetByIdSectionQuery request, CancellationToken cancellationToken)
        {
            Section? section = await _sectionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionBusinessRules.SectionShouldExistWhenSelected(section);

            GetByIdSectionResponse response = _mapper.Map<GetByIdSectionResponse>(section);
            return response;
        }
    }
}
using Application.Features.SectionAbouts.Constants;
using Application.Features.SectionAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SectionAbouts.Constants.SectionAboutsOperationClaims;

namespace Application.Features.SectionAbouts.Queries.GetById;

public class GetByIdSectionAboutQuery : IRequest<GetByIdSectionAboutResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSectionAboutQueryHandler : IRequestHandler<GetByIdSectionAboutQuery, GetByIdSectionAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionAboutRepository _sectionAboutRepository;
        private readonly SectionAboutBusinessRules _sectionAboutBusinessRules;

        public GetByIdSectionAboutQueryHandler(IMapper mapper, ISectionAboutRepository sectionAboutRepository, SectionAboutBusinessRules sectionAboutBusinessRules)
        {
            _mapper = mapper;
            _sectionAboutRepository = sectionAboutRepository;
            _sectionAboutBusinessRules = sectionAboutBusinessRules;
        }

        public async Task<GetByIdSectionAboutResponse> Handle(GetByIdSectionAboutQuery request, CancellationToken cancellationToken)
        {
            SectionAbout? sectionAbout = await _sectionAboutRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionAboutBusinessRules.SectionAboutShouldExistWhenSelected(sectionAbout);

            GetByIdSectionAboutResponse response = _mapper.Map<GetByIdSectionAboutResponse>(sectionAbout);
            return response;
        }
    }
}
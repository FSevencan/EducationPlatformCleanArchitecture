using Application.Features.SectionAbouts.Constants;
using Application.Features.SectionAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SectionAbouts.Constants.SectionAboutsOperationClaims;

namespace Application.Features.SectionAbouts.Commands.Update;

public class UpdateSectionAboutCommand : IRequest<UpdatedSectionAboutResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }
    public string? Text { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double EstimatedDuration { get; set; }
    public Section Section { get; set; }
    public ProducerCompany ProducerCompany { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionAboutsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionAbouts";

    public class UpdateSectionAboutCommandHandler : IRequestHandler<UpdateSectionAboutCommand, UpdatedSectionAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionAboutRepository _sectionAboutRepository;
        private readonly SectionAboutBusinessRules _sectionAboutBusinessRules;

        public UpdateSectionAboutCommandHandler(IMapper mapper, ISectionAboutRepository sectionAboutRepository,
                                         SectionAboutBusinessRules sectionAboutBusinessRules)
        {
            _mapper = mapper;
            _sectionAboutRepository = sectionAboutRepository;
            _sectionAboutBusinessRules = sectionAboutBusinessRules;
        }

        public async Task<UpdatedSectionAboutResponse> Handle(UpdateSectionAboutCommand request, CancellationToken cancellationToken)
        {
            SectionAbout? sectionAbout = await _sectionAboutRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionAboutBusinessRules.SectionAboutShouldExistWhenSelected(sectionAbout);
            sectionAbout = _mapper.Map(request, sectionAbout);

            await _sectionAboutRepository.UpdateAsync(sectionAbout!);

            UpdatedSectionAboutResponse response = _mapper.Map<UpdatedSectionAboutResponse>(sectionAbout);
            return response;
        }
    }
}
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

namespace Application.Features.SectionAbouts.Commands.Create;

public class CreateSectionAboutCommand : IRequest<CreatedSectionAboutResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ProducerCompanyId { get; set; }
    public Guid SectionId { get; set; }
    public string? Text { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double EstimatedDuration { get; set; }
    

    public string[] Roles => new[] { Admin, Write, SectionAboutsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionAbouts";

    public class CreateSectionAboutCommandHandler : IRequestHandler<CreateSectionAboutCommand, CreatedSectionAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionAboutRepository _sectionAboutRepository;
        private readonly SectionAboutBusinessRules _sectionAboutBusinessRules;

        public CreateSectionAboutCommandHandler(IMapper mapper, ISectionAboutRepository sectionAboutRepository,
                                         SectionAboutBusinessRules sectionAboutBusinessRules)
        {
            _mapper = mapper;
            _sectionAboutRepository = sectionAboutRepository;
            _sectionAboutBusinessRules = sectionAboutBusinessRules;
        }

        public async Task<CreatedSectionAboutResponse> Handle(CreateSectionAboutCommand request, CancellationToken cancellationToken)
        {
            SectionAbout sectionAbout = _mapper.Map<SectionAbout>(request);

            await _sectionAboutRepository.AddAsync(sectionAbout);

            CreatedSectionAboutResponse response = _mapper.Map<CreatedSectionAboutResponse>(sectionAbout);
            return response;
        }
    }
}
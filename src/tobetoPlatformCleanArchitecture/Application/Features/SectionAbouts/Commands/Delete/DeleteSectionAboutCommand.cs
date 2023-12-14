using Application.Features.SectionAbouts.Constants;
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

namespace Application.Features.SectionAbouts.Commands.Delete;

public class DeleteSectionAboutCommand : IRequest<DeletedSectionAboutResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionAboutsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionAbouts";

    public class DeleteSectionAboutCommandHandler : IRequestHandler<DeleteSectionAboutCommand, DeletedSectionAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionAboutRepository _sectionAboutRepository;
        private readonly SectionAboutBusinessRules _sectionAboutBusinessRules;

        public DeleteSectionAboutCommandHandler(IMapper mapper, ISectionAboutRepository sectionAboutRepository,
                                         SectionAboutBusinessRules sectionAboutBusinessRules)
        {
            _mapper = mapper;
            _sectionAboutRepository = sectionAboutRepository;
            _sectionAboutBusinessRules = sectionAboutBusinessRules;
        }

        public async Task<DeletedSectionAboutResponse> Handle(DeleteSectionAboutCommand request, CancellationToken cancellationToken)
        {
            SectionAbout? sectionAbout = await _sectionAboutRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionAboutBusinessRules.SectionAboutShouldExistWhenSelected(sectionAbout);

            await _sectionAboutRepository.DeleteAsync(sectionAbout!);

            DeletedSectionAboutResponse response = _mapper.Map<DeletedSectionAboutResponse>(sectionAbout);
            return response;
        }
    }
}
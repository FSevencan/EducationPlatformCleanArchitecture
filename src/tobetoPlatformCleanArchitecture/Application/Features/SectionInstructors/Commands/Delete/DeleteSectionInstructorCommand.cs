using Application.Features.SectionInstructors.Constants;
using Application.Features.SectionInstructors.Constants;
using Application.Features.SectionInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SectionInstructors.Constants.SectionInstructorsOperationClaims;

namespace Application.Features.SectionInstructors.Commands.Delete;

public class DeleteSectionInstructorCommand : IRequest<DeletedSectionInstructorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionInstructorsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionInstructors";

    public class DeleteSectionInstructorCommandHandler : IRequestHandler<DeleteSectionInstructorCommand, DeletedSectionInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionInstructorRepository _sectionInstructorRepository;
        private readonly SectionInstructorBusinessRules _sectionInstructorBusinessRules;

        public DeleteSectionInstructorCommandHandler(IMapper mapper, ISectionInstructorRepository sectionInstructorRepository,
                                         SectionInstructorBusinessRules sectionInstructorBusinessRules)
        {
            _mapper = mapper;
            _sectionInstructorRepository = sectionInstructorRepository;
            _sectionInstructorBusinessRules = sectionInstructorBusinessRules;
        }

        public async Task<DeletedSectionInstructorResponse> Handle(DeleteSectionInstructorCommand request, CancellationToken cancellationToken)
        {
            SectionInstructor? sectionInstructor = await _sectionInstructorRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionInstructorBusinessRules.SectionInstructorShouldExistWhenSelected(sectionInstructor);

            await _sectionInstructorRepository.DeleteAsync(sectionInstructor!);

            DeletedSectionInstructorResponse response = _mapper.Map<DeletedSectionInstructorResponse>(sectionInstructor);
            return response;
        }
    }
}
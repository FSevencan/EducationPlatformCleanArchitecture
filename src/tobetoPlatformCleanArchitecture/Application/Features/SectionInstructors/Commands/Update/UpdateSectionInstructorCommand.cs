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

namespace Application.Features.SectionInstructors.Commands.Update;

public class UpdateSectionInstructorCommand : IRequest<UpdatedSectionInstructorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }
    public Section Section { get; set; }
    public Instructor Instructor { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionInstructorsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionInstructors";

    public class UpdateSectionInstructorCommandHandler : IRequestHandler<UpdateSectionInstructorCommand, UpdatedSectionInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionInstructorRepository _sectionInstructorRepository;
        private readonly SectionInstructorBusinessRules _sectionInstructorBusinessRules;

        public UpdateSectionInstructorCommandHandler(IMapper mapper, ISectionInstructorRepository sectionInstructorRepository,
                                         SectionInstructorBusinessRules sectionInstructorBusinessRules)
        {
            _mapper = mapper;
            _sectionInstructorRepository = sectionInstructorRepository;
            _sectionInstructorBusinessRules = sectionInstructorBusinessRules;
        }

        public async Task<UpdatedSectionInstructorResponse> Handle(UpdateSectionInstructorCommand request, CancellationToken cancellationToken)
        {
            SectionInstructor? sectionInstructor = await _sectionInstructorRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionInstructorBusinessRules.SectionInstructorShouldExistWhenSelected(sectionInstructor);
            sectionInstructor = _mapper.Map(request, sectionInstructor);

            await _sectionInstructorRepository.UpdateAsync(sectionInstructor!);

            UpdatedSectionInstructorResponse response = _mapper.Map<UpdatedSectionInstructorResponse>(sectionInstructor);
            return response;
        }
    }
}
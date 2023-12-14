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

namespace Application.Features.SectionInstructors.Commands.Create;

public class CreateSectionInstructorCommand : IRequest<CreatedSectionInstructorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SectionId { get; set; }
    public Guid InstructorId { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionInstructorsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionInstructors";

    public class CreateSectionInstructorCommandHandler : IRequestHandler<CreateSectionInstructorCommand, CreatedSectionInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionInstructorRepository _sectionInstructorRepository;
        private readonly SectionInstructorBusinessRules _sectionInstructorBusinessRules;

        public CreateSectionInstructorCommandHandler(IMapper mapper, ISectionInstructorRepository sectionInstructorRepository,
                                         SectionInstructorBusinessRules sectionInstructorBusinessRules)
        {
            _mapper = mapper;
            _sectionInstructorRepository = sectionInstructorRepository;
            _sectionInstructorBusinessRules = sectionInstructorBusinessRules;
        }

        public async Task<CreatedSectionInstructorResponse> Handle(CreateSectionInstructorCommand request, CancellationToken cancellationToken)
        {
            SectionInstructor sectionInstructor = _mapper.Map<SectionInstructor>(request);

            await _sectionInstructorRepository.AddAsync(sectionInstructor);

            CreatedSectionInstructorResponse response = _mapper.Map<CreatedSectionInstructorResponse>(sectionInstructor);
            return response;
        }
    }
}
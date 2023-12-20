using Application.Features.StudentSections.Constants;
using Application.Features.StudentSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentSections.Constants.StudentSectionsOperationClaims;

namespace Application.Features.StudentSections.Commands.Create;

public class CreateStudentSectionCommand : IRequest<CreatedStudentSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSectionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSections";

    public class CreateStudentSectionCommandHandler : IRequestHandler<CreateStudentSectionCommand, CreatedStudentSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly StudentSectionBusinessRules _studentSectionBusinessRules;

        public CreateStudentSectionCommandHandler(IMapper mapper, IStudentSectionRepository studentSectionRepository,
                                         StudentSectionBusinessRules studentSectionBusinessRules)
        {
            _mapper = mapper;
            _studentSectionRepository = studentSectionRepository;
            _studentSectionBusinessRules = studentSectionBusinessRules;
        }

        public async Task<CreatedStudentSectionResponse> Handle(CreateStudentSectionCommand request, CancellationToken cancellationToken)
        {
            StudentSection studentSection = _mapper.Map<StudentSection>(request);

            await _studentSectionRepository.AddAsync(studentSection);

            CreatedStudentSectionResponse response = _mapper.Map<CreatedStudentSectionResponse>(studentSection);
            return response;
        }
    }
}
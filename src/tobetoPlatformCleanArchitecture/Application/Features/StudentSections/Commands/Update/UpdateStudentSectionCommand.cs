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

namespace Application.Features.StudentSections.Commands.Update;

public class UpdateStudentSectionCommand : IRequest<UpdatedStudentSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid SectionId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSectionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSections";

    public class UpdateStudentSectionCommandHandler : IRequestHandler<UpdateStudentSectionCommand, UpdatedStudentSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly StudentSectionBusinessRules _studentSectionBusinessRules;

        public UpdateStudentSectionCommandHandler(IMapper mapper, IStudentSectionRepository studentSectionRepository,
                                         StudentSectionBusinessRules studentSectionBusinessRules)
        {
            _mapper = mapper;
            _studentSectionRepository = studentSectionRepository;
            _studentSectionBusinessRules = studentSectionBusinessRules;
        }

        public async Task<UpdatedStudentSectionResponse> Handle(UpdateStudentSectionCommand request, CancellationToken cancellationToken)
        {
            StudentSection? studentSection = await _studentSectionRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSectionBusinessRules.StudentSectionShouldExistWhenSelected(studentSection);
            studentSection = _mapper.Map(request, studentSection);

            await _studentSectionRepository.UpdateAsync(studentSection!);

            UpdatedStudentSectionResponse response = _mapper.Map<UpdatedStudentSectionResponse>(studentSection);
            return response;
        }
    }
}
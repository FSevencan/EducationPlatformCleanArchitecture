using Application.Features.StudentSections.Constants;
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

namespace Application.Features.StudentSections.Commands.Delete;

public class DeleteStudentSectionCommand : IRequest<DeletedStudentSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSectionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSections";

    public class DeleteStudentSectionCommandHandler : IRequestHandler<DeleteStudentSectionCommand, DeletedStudentSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly StudentSectionBusinessRules _studentSectionBusinessRules;

        public DeleteStudentSectionCommandHandler(IMapper mapper, IStudentSectionRepository studentSectionRepository,
                                         StudentSectionBusinessRules studentSectionBusinessRules)
        {
            _mapper = mapper;
            _studentSectionRepository = studentSectionRepository;
            _studentSectionBusinessRules = studentSectionBusinessRules;
        }

        public async Task<DeletedStudentSectionResponse> Handle(DeleteStudentSectionCommand request, CancellationToken cancellationToken)
        {
            StudentSection? studentSection = await _studentSectionRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSectionBusinessRules.StudentSectionShouldExistWhenSelected(studentSection);

            await _studentSectionRepository.DeleteAsync(studentSection!);

            DeletedStudentSectionResponse response = _mapper.Map<DeletedStudentSectionResponse>(studentSection);
            return response;
        }
    }
}
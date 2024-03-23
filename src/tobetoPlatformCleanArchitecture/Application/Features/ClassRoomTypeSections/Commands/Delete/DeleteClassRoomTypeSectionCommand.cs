using Application.Features.ClassRoomTypeSections.Constants;
using Application.Features.ClassRoomTypeSections.Constants;
using Application.Features.ClassRoomTypeSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ClassRoomTypeSections.Constants.ClassRoomTypeSectionsOperationClaims;

namespace Application.Features.ClassRoomTypeSections.Commands.Delete;

public class DeleteClassRoomTypeSectionCommand : IRequest<DeletedClassRoomTypeSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassRoomTypeSectionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRoomTypeSections";

    public class DeleteClassRoomTypeSectionCommandHandler : IRequestHandler<DeleteClassRoomTypeSectionCommand, DeletedClassRoomTypeSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
        private readonly ClassRoomTypeSectionBusinessRules _classRoomTypeSectionBusinessRules;

        public DeleteClassRoomTypeSectionCommandHandler(IMapper mapper, IClassRoomTypeSectionRepository classRoomTypeSectionRepository,
                                         ClassRoomTypeSectionBusinessRules classRoomTypeSectionBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
            _classRoomTypeSectionBusinessRules = classRoomTypeSectionBusinessRules;
        }

        public async Task<DeletedClassRoomTypeSectionResponse> Handle(DeleteClassRoomTypeSectionCommand request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection? classRoomTypeSection = await _classRoomTypeSectionRepository.GetAsync(predicate: crts => crts.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomTypeSectionBusinessRules.ClassRoomTypeSectionShouldExistWhenSelected(classRoomTypeSection);

            await _classRoomTypeSectionRepository.DeleteAsync(classRoomTypeSection!);

            DeletedClassRoomTypeSectionResponse response = _mapper.Map<DeletedClassRoomTypeSectionResponse>(classRoomTypeSection);
            return response;
        }
    }
}
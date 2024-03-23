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

namespace Application.Features.ClassRoomTypeSections.Commands.Update;

public class UpdateClassRoomTypeSectionCommand : IRequest<UpdatedClassRoomTypeSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
   

    public string[] Roles => new[] { Admin, Write, ClassRoomTypeSectionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRoomTypeSections";

    public class UpdateClassRoomTypeSectionCommandHandler : IRequestHandler<UpdateClassRoomTypeSectionCommand, UpdatedClassRoomTypeSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
        private readonly ClassRoomTypeSectionBusinessRules _classRoomTypeSectionBusinessRules;

        public UpdateClassRoomTypeSectionCommandHandler(IMapper mapper, IClassRoomTypeSectionRepository classRoomTypeSectionRepository,
                                         ClassRoomTypeSectionBusinessRules classRoomTypeSectionBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
            _classRoomTypeSectionBusinessRules = classRoomTypeSectionBusinessRules;
        }

        public async Task<UpdatedClassRoomTypeSectionResponse> Handle(UpdateClassRoomTypeSectionCommand request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection? classRoomTypeSection = await _classRoomTypeSectionRepository.GetAsync(predicate: crts => crts.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomTypeSectionBusinessRules.ClassRoomTypeSectionShouldExistWhenSelected(classRoomTypeSection);
            classRoomTypeSection = _mapper.Map(request, classRoomTypeSection);

            await _classRoomTypeSectionRepository.UpdateAsync(classRoomTypeSection!);

            UpdatedClassRoomTypeSectionResponse response = _mapper.Map<UpdatedClassRoomTypeSectionResponse>(classRoomTypeSection);
            return response;
        }
    }
}
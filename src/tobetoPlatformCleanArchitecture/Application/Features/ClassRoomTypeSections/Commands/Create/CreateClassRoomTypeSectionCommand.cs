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

namespace Application.Features.ClassRoomTypeSections.Commands.Create;

public class CreateClassRoomTypeSectionCommand : IRequest<CreatedClassRoomTypeSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ClassRoomTypeId { get; set; }
    public Guid SectionId { get; set; }
    

    public string[] Roles => new[] { Admin, Write, ClassRoomTypeSectionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRoomTypeSections";

    public class CreateClassRoomTypeSectionCommandHandler : IRequestHandler<CreateClassRoomTypeSectionCommand, CreatedClassRoomTypeSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
        private readonly ClassRoomTypeSectionBusinessRules _classRoomTypeSectionBusinessRules;

        public CreateClassRoomTypeSectionCommandHandler(IMapper mapper, IClassRoomTypeSectionRepository classRoomTypeSectionRepository,
                                         ClassRoomTypeSectionBusinessRules classRoomTypeSectionBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
            _classRoomTypeSectionBusinessRules = classRoomTypeSectionBusinessRules;
        }

        public async Task<CreatedClassRoomTypeSectionResponse> Handle(CreateClassRoomTypeSectionCommand request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection classRoomTypeSection = _mapper.Map<ClassRoomTypeSection>(request);

            await _classRoomTypeSectionRepository.AddAsync(classRoomTypeSection);

            CreatedClassRoomTypeSectionResponse response = _mapper.Map<CreatedClassRoomTypeSectionResponse>(classRoomTypeSection);
            return response;
        }
    }
}
using Application.Features.ClassRoomTypes.Constants;
using Application.Features.ClassRoomTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ClassRoomTypes.Constants.ClassRoomTypesOperationClaims;

namespace Application.Features.ClassRoomTypes.Commands.Create;

public class CreateClassRoomTypeCommand : IRequest<CreatedClassRoomTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public ICollection<Guid> SectionIds { get; set; }


    public string[] Roles => new[] { Admin, Write, ClassRoomTypesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRoomTypes";

    public class CreateClassRoomTypeCommandHandler : IRequestHandler<CreateClassRoomTypeCommand, CreatedClassRoomTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeRepository _classRoomTypeRepository;
        private readonly ClassRoomTypeBusinessRules _classRoomTypeBusinessRules;

        public CreateClassRoomTypeCommandHandler(IMapper mapper, IClassRoomTypeRepository classRoomTypeRepository,
                                         ClassRoomTypeBusinessRules classRoomTypeBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeRepository = classRoomTypeRepository;
            _classRoomTypeBusinessRules = classRoomTypeBusinessRules;
        }

        public async Task<CreatedClassRoomTypeResponse> Handle(CreateClassRoomTypeCommand request, CancellationToken cancellationToken)
        {
            ClassRoomType classRoomType = _mapper.Map<ClassRoomType>(request);

            classRoomType.ClassRoomTypeSection = request.SectionIds.Select
                (sectionId => new ClassRoomTypeSection
                {
                    SectionId = sectionId,
                    CreatedDate = DateTime.Now
                }).ToList();

            await _classRoomTypeRepository.AddAsync(classRoomType);

            CreatedClassRoomTypeResponse response = _mapper.Map<CreatedClassRoomTypeResponse>(classRoomType);
            return response;
        }
    }
}
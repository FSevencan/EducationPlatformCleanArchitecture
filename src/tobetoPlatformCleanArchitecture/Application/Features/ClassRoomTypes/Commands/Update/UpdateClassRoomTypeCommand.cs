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

namespace Application.Features.ClassRoomTypes.Commands.Update;

public class UpdateClassRoomTypeCommand : IRequest<UpdatedClassRoomTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassRoomTypesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRoomTypes";

    public class UpdateClassRoomTypeCommandHandler : IRequestHandler<UpdateClassRoomTypeCommand, UpdatedClassRoomTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeRepository _classRoomTypeRepository;
        private readonly ClassRoomTypeBusinessRules _classRoomTypeBusinessRules;

        public UpdateClassRoomTypeCommandHandler(IMapper mapper, IClassRoomTypeRepository classRoomTypeRepository,
                                         ClassRoomTypeBusinessRules classRoomTypeBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeRepository = classRoomTypeRepository;
            _classRoomTypeBusinessRules = classRoomTypeBusinessRules;
        }

        public async Task<UpdatedClassRoomTypeResponse> Handle(UpdateClassRoomTypeCommand request, CancellationToken cancellationToken)
        {
            ClassRoomType? classRoomType = await _classRoomTypeRepository.GetAsync(predicate: crt => crt.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomTypeBusinessRules.ClassRoomTypeShouldExistWhenSelected(classRoomType);
            classRoomType = _mapper.Map(request, classRoomType);

            await _classRoomTypeRepository.UpdateAsync(classRoomType!);

            UpdatedClassRoomTypeResponse response = _mapper.Map<UpdatedClassRoomTypeResponse>(classRoomType);
            return response;
        }
    }
}
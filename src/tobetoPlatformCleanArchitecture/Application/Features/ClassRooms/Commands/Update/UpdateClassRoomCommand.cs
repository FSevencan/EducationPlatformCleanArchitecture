using Application.Features.ClassRooms.Constants;
using Application.Features.ClassRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ClassRooms.Constants.ClassRoomsOperationClaims;

namespace Application.Features.ClassRooms.Commands.Update;

public class UpdateClassRoomCommand : IRequest<UpdatedClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassRoomsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRooms";

    public class UpdateClassRoomCommandHandler : IRequestHandler<UpdateClassRoomCommand, UpdatedClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ClassRoomBusinessRules _classRoomBusinessRules;

        public UpdateClassRoomCommandHandler(IMapper mapper, IClassRoomRepository classRoomRepository,
                                         ClassRoomBusinessRules classRoomBusinessRules)
        {
            _mapper = mapper;
            _classRoomRepository = classRoomRepository;
            _classRoomBusinessRules = classRoomBusinessRules;
        }

        public async Task<UpdatedClassRoomResponse> Handle(UpdateClassRoomCommand request, CancellationToken cancellationToken)
        {
            ClassRoom? classRoom = await _classRoomRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomBusinessRules.ClassRoomShouldExistWhenSelected(classRoom);
            classRoom = _mapper.Map(request, classRoom);

            await _classRoomRepository.UpdateAsync(classRoom!);

            UpdatedClassRoomResponse response = _mapper.Map<UpdatedClassRoomResponse>(classRoom);
            return response;
        }
    }
}
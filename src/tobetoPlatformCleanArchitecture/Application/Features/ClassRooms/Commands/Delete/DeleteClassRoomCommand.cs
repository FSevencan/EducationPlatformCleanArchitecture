using Application.Features.ClassRooms.Constants;
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

namespace Application.Features.ClassRooms.Commands.Delete;

public class DeleteClassRoomCommand : IRequest<DeletedClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassRoomsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRooms";

    public class DeleteClassRoomCommandHandler : IRequestHandler<DeleteClassRoomCommand, DeletedClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ClassRoomBusinessRules _classRoomBusinessRules;

        public DeleteClassRoomCommandHandler(IMapper mapper, IClassRoomRepository classRoomRepository,
                                         ClassRoomBusinessRules classRoomBusinessRules)
        {
            _mapper = mapper;
            _classRoomRepository = classRoomRepository;
            _classRoomBusinessRules = classRoomBusinessRules;
        }

        public async Task<DeletedClassRoomResponse> Handle(DeleteClassRoomCommand request, CancellationToken cancellationToken)
        {
            ClassRoom? classRoom = await _classRoomRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomBusinessRules.ClassRoomShouldExistWhenSelected(classRoom);

            await _classRoomRepository.DeleteAsync(classRoom!);

            DeletedClassRoomResponse response = _mapper.Map<DeletedClassRoomResponse>(classRoom);
            return response;
        }
    }
}
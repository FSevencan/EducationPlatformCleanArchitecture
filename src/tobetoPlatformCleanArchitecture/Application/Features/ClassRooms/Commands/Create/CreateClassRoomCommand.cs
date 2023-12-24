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

namespace Application.Features.ClassRooms.Commands.Create;

public class CreateClassRoomCommand : IRequest<CreatedClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Branch { get; set; }
    public Guid ClassRoomTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassRoomsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassRooms";

    public class CreateClassRoomCommandHandler : IRequestHandler<CreateClassRoomCommand, CreatedClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ClassRoomBusinessRules _classRoomBusinessRules;

        public CreateClassRoomCommandHandler(IMapper mapper, IClassRoomRepository classRoomRepository,
                                         ClassRoomBusinessRules classRoomBusinessRules)
        {
            _mapper = mapper;
            _classRoomRepository = classRoomRepository;
            _classRoomBusinessRules = classRoomBusinessRules;
        }

        public async Task<CreatedClassRoomResponse> Handle(CreateClassRoomCommand request, CancellationToken cancellationToken)
        {
            ClassRoom classRoom = _mapper.Map<ClassRoom>(request);

            await _classRoomRepository.AddAsync(classRoom);

            CreatedClassRoomResponse response = _mapper.Map<CreatedClassRoomResponse>(classRoom);
            return response;
        }
    }
}
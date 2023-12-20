using Application.Features.ClassRooms.Constants;
using Application.Features.ClassRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ClassRooms.Constants.ClassRoomsOperationClaims;

namespace Application.Features.ClassRooms.Queries.GetById;

public class GetByIdClassRoomQuery : IRequest<GetByIdClassRoomResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdClassRoomQueryHandler : IRequestHandler<GetByIdClassRoomQuery, GetByIdClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ClassRoomBusinessRules _classRoomBusinessRules;

        public GetByIdClassRoomQueryHandler(IMapper mapper, IClassRoomRepository classRoomRepository, ClassRoomBusinessRules classRoomBusinessRules)
        {
            _mapper = mapper;
            _classRoomRepository = classRoomRepository;
            _classRoomBusinessRules = classRoomBusinessRules;
        }

        public async Task<GetByIdClassRoomResponse> Handle(GetByIdClassRoomQuery request, CancellationToken cancellationToken)
        {
            ClassRoom? classRoom = await _classRoomRepository.GetAsync(predicate: cr => cr.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomBusinessRules.ClassRoomShouldExistWhenSelected(classRoom);

            GetByIdClassRoomResponse response = _mapper.Map<GetByIdClassRoomResponse>(classRoom);
            return response;
        }
    }
}
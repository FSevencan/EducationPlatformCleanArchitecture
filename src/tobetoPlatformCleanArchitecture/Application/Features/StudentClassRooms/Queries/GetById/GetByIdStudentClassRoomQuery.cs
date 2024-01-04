using Application.Features.StudentClassRooms.Constants;
using Application.Features.StudentClassRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentClassRooms.Constants.StudentClassRoomsOperationClaims;

namespace Application.Features.StudentClassRooms.Queries.GetById;

public class GetByIdStudentClassRoomQuery : IRequest<GetByIdStudentClassRoomResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentClassRoomQueryHandler : IRequestHandler<GetByIdStudentClassRoomQuery, GetByIdStudentClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassRoomRepository _studentClassRoomRepository;
        private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

        public GetByIdStudentClassRoomQueryHandler(IMapper mapper, IStudentClassRoomRepository studentClassRoomRepository, StudentClassRoomBusinessRules studentClassRoomBusinessRules)
        {
            _mapper = mapper;
            _studentClassRoomRepository = studentClassRoomRepository;
            _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
        }

        public async Task<GetByIdStudentClassRoomResponse> Handle(GetByIdStudentClassRoomQuery request, CancellationToken cancellationToken)
        {
            StudentClassRoom? studentClassRoom = await _studentClassRoomRepository.GetAsync(predicate: scr => scr.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassRoomBusinessRules.StudentClassRoomShouldExistWhenSelected(studentClassRoom);

            GetByIdStudentClassRoomResponse response = _mapper.Map<GetByIdStudentClassRoomResponse>(studentClassRoom);
            return response;
        }
    }
}
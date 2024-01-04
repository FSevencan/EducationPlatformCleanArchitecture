using Application.Features.StudentClassRooms.Constants;
using Application.Features.StudentClassRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentClassRooms.Constants.StudentClassRoomsOperationClaims;

namespace Application.Features.StudentClassRooms.Commands.Create;

public class CreateStudentClassRoomCommand : IRequest<CreatedStudentClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int StudentId { get; set; }
    public Guid ClassRoomId { get; set; }
    

    public string[] Roles => new[] { Admin, Write, StudentClassRoomsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentClassRooms";

    public class CreateStudentClassRoomCommandHandler : IRequestHandler<CreateStudentClassRoomCommand, CreatedStudentClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassRoomRepository _studentClassRoomRepository;
        private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

        public CreateStudentClassRoomCommandHandler(IMapper mapper, IStudentClassRoomRepository studentClassRoomRepository,
                                         StudentClassRoomBusinessRules studentClassRoomBusinessRules)
        {
            _mapper = mapper;
            _studentClassRoomRepository = studentClassRoomRepository;
            _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
        }

        public async Task<CreatedStudentClassRoomResponse> Handle(CreateStudentClassRoomCommand request, CancellationToken cancellationToken)
        {
            StudentClassRoom studentClassRoom = _mapper.Map<StudentClassRoom>(request);

            await _studentClassRoomRepository.AddAsync(studentClassRoom);

            CreatedStudentClassRoomResponse response = _mapper.Map<CreatedStudentClassRoomResponse>(studentClassRoom);
            return response;
        }
    }
}
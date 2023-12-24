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

namespace Application.Features.StudentClassRooms.Commands.Update;

public class UpdateStudentClassRoomCommand : IRequest<UpdatedStudentClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public int ClassRoomId { get; set; }
   

    public string[] Roles => new[] { Admin, Write, StudentClassRoomsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentClassRooms";

    public class UpdateStudentClassRoomCommandHandler : IRequestHandler<UpdateStudentClassRoomCommand, UpdatedStudentClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassRoomRepository _studentClassRoomRepository;
        private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

        public UpdateStudentClassRoomCommandHandler(IMapper mapper, IStudentClassRoomRepository studentClassRoomRepository,
                                         StudentClassRoomBusinessRules studentClassRoomBusinessRules)
        {
            _mapper = mapper;
            _studentClassRoomRepository = studentClassRoomRepository;
            _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
        }

        public async Task<UpdatedStudentClassRoomResponse> Handle(UpdateStudentClassRoomCommand request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection? studentClassRoom = await _studentClassRoomRepository.GetAsync(predicate: scr => scr.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassRoomBusinessRules.StudentClassRoomShouldExistWhenSelected(studentClassRoom);
            studentClassRoom = _mapper.Map(request, studentClassRoom);

            await _studentClassRoomRepository.UpdateAsync(studentClassRoom!);

            UpdatedStudentClassRoomResponse response = _mapper.Map<UpdatedStudentClassRoomResponse>(studentClassRoom);
            return response;
        }
    }
}
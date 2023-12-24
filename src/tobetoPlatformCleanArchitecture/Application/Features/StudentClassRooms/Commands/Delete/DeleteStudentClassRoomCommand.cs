using Application.Features.StudentClassRooms.Constants;
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

namespace Application.Features.StudentClassRooms.Commands.Delete;

public class DeleteStudentClassRoomCommand : IRequest<DeletedStudentClassRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentClassRoomsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentClassRooms";

    public class DeleteStudentClassRoomCommandHandler : IRequestHandler<DeleteStudentClassRoomCommand, DeletedStudentClassRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassRoomRepository _studentClassRoomRepository;
        private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

        public DeleteStudentClassRoomCommandHandler(IMapper mapper, IStudentClassRoomRepository studentClassRoomRepository,
                                         StudentClassRoomBusinessRules studentClassRoomBusinessRules)
        {
            _mapper = mapper;
            _studentClassRoomRepository = studentClassRoomRepository;
            _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
        }

        public async Task<DeletedStudentClassRoomResponse> Handle(DeleteStudentClassRoomCommand request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection? studentClassRoom = await _studentClassRoomRepository.GetAsync(predicate: scr => scr.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassRoomBusinessRules.StudentClassRoomShouldExistWhenSelected(studentClassRoom);

            await _studentClassRoomRepository.DeleteAsync(studentClassRoom!);

            DeletedStudentClassRoomResponse response = _mapper.Map<DeletedStudentClassRoomResponse>(studentClassRoom);
            return response;
        }
    }
}
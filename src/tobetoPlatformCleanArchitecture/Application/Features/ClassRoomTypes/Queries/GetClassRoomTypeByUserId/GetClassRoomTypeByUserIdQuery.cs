using Application.Features.StudentClassRooms.Rules;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ClassRoomTypes.Queries.GetClassRoomTypeByUserId;
public class GetClassRoomTypeByUserIdQuery : IRequest<GetClassRoomTypeByUserIdResponse>
{
    public int UserId { get; set; }

    public class GetClassRoomTypeByUserIdQueryHandler : IRequestHandler<GetClassRoomTypeByUserIdQuery, GetClassRoomTypeByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeRepository _classRoomTypeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

        public GetClassRoomTypeByUserIdQueryHandler(IMapper mapper, IClassRoomTypeRepository classRoomTypeRepository, StudentBusinessRules studentBusinessRules,
        StudentClassRoomBusinessRules studentClassRoomBusinessRules , IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _classRoomTypeRepository = classRoomTypeRepository;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
        }

        public async Task<GetClassRoomTypeByUserIdResponse> Handle(GetClassRoomTypeByUserIdQuery request, CancellationToken cancellationToken)
        {
            await _studentBusinessRules.UserIdShouldExistWhenSelected(request.UserId, cancellationToken);

            var student = await _studentRepository.GetAsync(
                s => s.UserId == request.UserId,
                include: q => q.Include(s => s.StudentClassRooms).ThenInclude(scr => scr.ClassRoom),
                cancellationToken: cancellationToken
            );

           await _studentClassRoomBusinessRules.StudentShouldBeAssignedToClassRoom(student);

            var classRoomType = await _classRoomTypeRepository.GetAsync(
                crt => crt.Id == student.StudentClassRooms.FirstOrDefault().ClassRoom.ClassRoomTypeId,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<GetClassRoomTypeByUserIdResponse>(classRoomType);
            return response;
        }
    }
}
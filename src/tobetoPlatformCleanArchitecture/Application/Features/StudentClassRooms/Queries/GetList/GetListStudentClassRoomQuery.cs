using Application.Features.StudentClassRooms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentClassRooms.Constants.StudentClassRoomsOperationClaims;

namespace Application.Features.StudentClassRooms.Queries.GetList;

public class GetListStudentClassRoomQuery : IRequest<GetListResponse<GetListStudentClassRoomListItemDto>>/*, ISecuredRequest*/, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentClassRooms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentClassRooms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentClassRoomQueryHandler : IRequestHandler<GetListStudentClassRoomQuery, GetListResponse<GetListStudentClassRoomListItemDto>>
    {
        private readonly IStudentClassRoomRepository _studentClassRoomRepository;
        private readonly IMapper _mapper;

        public GetListStudentClassRoomQueryHandler(IStudentClassRoomRepository studentClassRoomRepository, IMapper mapper)
        {
            _studentClassRoomRepository = studentClassRoomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentClassRoomListItemDto>> Handle(GetListStudentClassRoomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentClassRoom> studentClassRooms = await _studentClassRoomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentClassRoomListItemDto> response = _mapper.Map<GetListResponse<GetListStudentClassRoomListItemDto>>(studentClassRooms);
            return response;
        }
    }
}
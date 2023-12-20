using Application.Features.ClassRooms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ClassRooms.Constants.ClassRoomsOperationClaims;

namespace Application.Features.ClassRooms.Queries.GetList;

public class GetListClassRoomQuery : IRequest<GetListResponse<GetListClassRoomListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListClassRooms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetClassRooms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListClassRoomQueryHandler : IRequestHandler<GetListClassRoomQuery, GetListResponse<GetListClassRoomListItemDto>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;

        public GetListClassRoomQueryHandler(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassRoomListItemDto>> Handle(GetListClassRoomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ClassRoom> classRooms = await _classRoomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassRoomListItemDto> response = _mapper.Map<GetListResponse<GetListClassRoomListItemDto>>(classRooms);
            return response;
        }
    }
}
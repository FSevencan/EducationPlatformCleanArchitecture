using Application.Features.ClassRoomTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ClassRoomTypes.Constants.ClassRoomTypesOperationClaims;

namespace Application.Features.ClassRoomTypes.Queries.GetList;

public class GetListClassRoomTypeQuery : IRequest<GetListResponse<GetListClassRoomTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListClassRoomTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetClassRoomTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListClassRoomTypeQueryHandler : IRequestHandler<GetListClassRoomTypeQuery, GetListResponse<GetListClassRoomTypeListItemDto>>
    {
        private readonly IClassRoomTypeRepository _classRoomTypeRepository;
        private readonly IMapper _mapper;

        public GetListClassRoomTypeQueryHandler(IClassRoomTypeRepository classRoomTypeRepository, IMapper mapper)
        {
            _classRoomTypeRepository = classRoomTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassRoomTypeListItemDto>> Handle(GetListClassRoomTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ClassRoomType> classRoomTypes = await _classRoomTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassRoomTypeListItemDto> response = _mapper.Map<GetListResponse<GetListClassRoomTypeListItemDto>>(classRoomTypes);
            return response;
        }
    }
}
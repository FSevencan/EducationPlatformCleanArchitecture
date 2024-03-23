using Application.Features.ClassRoomTypeSections.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ClassRoomTypeSections.Constants.ClassRoomTypeSectionsOperationClaims;

namespace Application.Features.ClassRoomTypeSections.Queries.GetList;

public class GetListClassRoomTypeSectionQuery : IRequest<GetListResponse<GetListClassRoomTypeSectionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListClassRoomTypeSections({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetClassRoomTypeSections";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListClassRoomTypeSectionQueryHandler : IRequestHandler<GetListClassRoomTypeSectionQuery, GetListResponse<GetListClassRoomTypeSectionListItemDto>>
    {
        private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
        private readonly IMapper _mapper;

        public GetListClassRoomTypeSectionQueryHandler(IClassRoomTypeSectionRepository classRoomTypeSectionRepository, IMapper mapper)
        {
            _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassRoomTypeSectionListItemDto>> Handle(GetListClassRoomTypeSectionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ClassRoomTypeSection> classRoomTypeSections = await _classRoomTypeSectionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassRoomTypeSectionListItemDto> response = _mapper.Map<GetListResponse<GetListClassRoomTypeSectionListItemDto>>(classRoomTypeSections);
            return response;
        }
    }
}
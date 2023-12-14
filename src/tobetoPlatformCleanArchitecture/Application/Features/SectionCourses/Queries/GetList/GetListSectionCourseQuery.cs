using Application.Features.SectionCourses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.SectionCourses.Constants.SectionCoursesOperationClaims;

namespace Application.Features.SectionCourses.Queries.GetList;

public class GetListSectionCourseQuery : IRequest<GetListResponse<GetListSectionCourseListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSectionCourses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSectionCourses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSectionCourseQueryHandler : IRequestHandler<GetListSectionCourseQuery, GetListResponse<GetListSectionCourseListItemDto>>
    {
        private readonly ISectionCourseRepository _sectionCourseRepository;
        private readonly IMapper _mapper;

        public GetListSectionCourseQueryHandler(ISectionCourseRepository sectionCourseRepository, IMapper mapper)
        {
            _sectionCourseRepository = sectionCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSectionCourseListItemDto>> Handle(GetListSectionCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SectionCourse> sectionCourses = await _sectionCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSectionCourseListItemDto> response = _mapper.Map<GetListResponse<GetListSectionCourseListItemDto>>(sectionCourses);
            return response;
        }
    }
}
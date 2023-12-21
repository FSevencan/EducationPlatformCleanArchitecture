using Application.Features.Sections.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sections.Constants.SectionsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sections.Queries.GetList;

public class GetListSectionQuery : IRequest<GetListResponse<GetListSectionListItemDto>>, /*ISecuredRequest*/ ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSections({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSections";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSectionQueryHandler : IRequestHandler<GetListSectionQuery, GetListResponse<GetListSectionListItemDto>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetListSectionQueryHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }


        public async Task<GetListResponse<GetListSectionListItemDto>> Handle(GetListSectionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Section> sections = await _sectionRepository.GetListAsync(
                include: section => section
                               .Include(category => category.Category)
                               .Include(section => section.SectionCourses)
                               .ThenInclude(course => course.Course)
                               .Include(section => section.SectionInstructors)
                               .ThenInclude(sectionInstructor => sectionInstructor.Instructor)
                               .Include(sabout => sabout.SectionAbout)
                               .ThenInclude(producer => producer.ProducerCompany),

                //predicate: section => section.DeletedDate == null,

                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSectionListItemDto> response = _mapper.Map<GetListResponse<GetListSectionListItemDto>>(sections);
            return response;
        }
    }
}
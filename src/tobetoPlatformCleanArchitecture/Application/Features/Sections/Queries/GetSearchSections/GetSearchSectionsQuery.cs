using Application.Features.Sections.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MailKit.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sections.Queries.GetSearchSections;
public class GetSearchSectionsQuery : IRequest<GetListResponse<GetSearchSectionListDto>>,  ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public string SearchTerm { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetSearchSections-{SearchTerm}-{PageRequest.PageIndex}-{PageRequest.PageSize}";
    public string CacheGroupKey => "GetSections";
    public TimeSpan? SlidingExpiration { get; }

    public class GetSearchSectionsQueryHandler : IRequestHandler<GetSearchSectionsQuery, GetListResponse<GetSearchSectionListDto>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSearchSectionsQueryHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }


        public async Task<GetListResponse<GetSearchSectionListDto>> Handle(GetSearchSectionsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Section> sections;
            {
                sections = await _sectionRepository.GetListAsync(
                     predicate: a => a.Name.Contains(request.SearchTerm) ||
                                a.Category.Name.Contains(request.SearchTerm),   
                    include: section => section
                                    .Include(category => category.Category)
                                     .Include(section => section.SectionInstructors)
                                    .ThenInclude(sectionInstructor => sectionInstructor.Instructor)
                                    .ThenInclude(a => a.User),    
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                );
            }
            GetListResponse<GetSearchSectionListDto> response = _mapper.Map<GetListResponse<GetSearchSectionListDto>>(sections);
            return response;
        }
    }
}


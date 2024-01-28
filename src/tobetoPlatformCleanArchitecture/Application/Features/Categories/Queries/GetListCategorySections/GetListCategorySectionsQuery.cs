using Application.Features.Categories.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetListCategorySections;
public class GetListCategorySectionsQuery : IRequest<GetListResponse<GetListCategorySectionsListItemDto>>
{
    public Guid CategoryId { get; set; }

    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCategorySectionsQueryHandler: IRequestHandler<GetListCategorySectionsQuery, GetListResponse<GetListCategorySectionsListItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetListCategorySectionsQueryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategorySectionsListItemDto>> Handle(GetListCategorySectionsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(
                predicate: c=>c.Id == request.CategoryId,
                include: c => c
                .Include(section => section.Sections)                                                                 
                .ThenInclude(s=>s.SectionInstructors)
                .ThenInclude(si=>si.Instructor)
                .ThenInclude(i=>i.User),            
                //predicate: c => c.DeletedDate == null,
                //withDeleted: true,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategorySectionsListItemDto> response = _mapper.Map<GetListResponse<GetListCategorySectionsListItemDto>>(categories);
            return response;
        }
    }
}

using Application.Features.SectionInstructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.SectionInstructors.Constants.SectionInstructorsOperationClaims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Extensions;

namespace Application.Features.SectionInstructors.Queries.GetList;

public class GetListSectionInstructorQuery : IRequest<GetListResponse<GetListSectionInstructorListItemDto>>/*, ISecuredRequest*//*, ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }
    public int? InstructorId { get; set; }
    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSectionInstructors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSectionInstructors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSectionInstructorQueryHandler : IRequestHandler<GetListSectionInstructorQuery, GetListResponse<GetListSectionInstructorListItemDto>>
    {
        private readonly ISectionInstructorRepository _sectionInstructorRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly IInstructorRepository _instructorRepository;

        public GetListSectionInstructorQueryHandler(ISectionInstructorRepository sectionInstructorRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IInstructorRepository instructorRepository)
        {
            _sectionInstructorRepository = sectionInstructorRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _instructorRepository = instructorRepository;
        }

        public async Task<GetListResponse<GetListSectionInstructorListItemDto>> Handle(GetListSectionInstructorQuery request, CancellationToken cancellationToken)
        {

            

            var sectionInstructors = await _sectionInstructorRepository.GetListAsync(
                instructor => instructor.InstructorId == instructorId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<GetListResponse<GetListSectionInstructorListItemDto>>(sectionInstructors);
            return response;
        }


    }
}
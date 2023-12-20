using Application.Features.StudentSections.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentSections.Constants.StudentSectionsOperationClaims;

namespace Application.Features.StudentSections.Queries.GetList;

public class GetListStudentSectionQuery : IRequest<GetListResponse<GetListStudentSectionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentSections({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentSections";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentSectionQueryHandler : IRequestHandler<GetListStudentSectionQuery, GetListResponse<GetListStudentSectionListItemDto>>
    {
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly IMapper _mapper;

        public GetListStudentSectionQueryHandler(IStudentSectionRepository studentSectionRepository, IMapper mapper)
        {
            _studentSectionRepository = studentSectionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentSectionListItemDto>> Handle(GetListStudentSectionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentSection> studentSections = await _studentSectionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentSectionListItemDto> response = _mapper.Map<GetListResponse<GetListStudentSectionListItemDto>>(studentSections);
            return response;
        }
    }
}
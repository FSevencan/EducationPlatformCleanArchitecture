using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Queries.GetList;

public class GetListInstructorQuery : IRequest<GetListResponse<GetListInstructorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListInstructors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetInstructors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInstructorQueryHandler : IRequestHandler<GetListInstructorQuery, GetListResponse<GetListInstructorListItemDto>>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public GetListInstructorQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInstructorListItemDto>> Handle(GetListInstructorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Instructor> instructors = await _instructorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInstructorListItemDto> response = _mapper.Map<GetListResponse<GetListInstructorListItemDto>>(instructors);
            return response;
        }
    }
}
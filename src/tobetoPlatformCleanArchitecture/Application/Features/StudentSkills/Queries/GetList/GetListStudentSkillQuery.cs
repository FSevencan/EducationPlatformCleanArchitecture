using Application.Features.StudentSkills.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentSkills.Constants.StudentSkillsOperationClaims;

namespace Application.Features.StudentSkills.Queries.GetList;

public class GetListStudentSkillQuery : IRequest<GetListResponse<GetListStudentSkillListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentSkills({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentSkills";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentSkillQueryHandler : IRequestHandler<GetListStudentSkillQuery, GetListResponse<GetListStudentSkillListItemDto>>
    {
        private readonly IStudentSkillRepository _studentSkillRepository;
        private readonly IMapper _mapper;

        public GetListStudentSkillQueryHandler(IStudentSkillRepository studentSkillRepository, IMapper mapper)
        {
            _studentSkillRepository = studentSkillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentSkillListItemDto>> Handle(GetListStudentSkillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentSkill> studentSkills = await _studentSkillRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentSkillListItemDto> response = _mapper.Map<GetListResponse<GetListStudentSkillListItemDto>>(studentSkills);
            return response;
        }
    }
}
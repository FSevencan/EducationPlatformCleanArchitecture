using Application.Features.Students.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentQuery : IRequest<GetListResponse<GetListStudentListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudents({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudents";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, GetListResponse<GetListStudentListItemDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetListStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentListItemDto>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Student> students = await _studentRepository.GetListAsync( 
                include: s => s.Include(user => user.User),   //.Include(c=>c.Certificates), ihtiyaca yönelik ekleriz çünkü burasý admin için geçerli
                //include: s => s.Include( user=> user.User).Include(skils => skils.StudentSkills).ThenInclude(skil => skil.SkillId), guid convert hatasý
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentListItemDto> response = _mapper.Map<GetListResponse<GetListStudentListItemDto>>(students);
            return response;
        }
    }
}
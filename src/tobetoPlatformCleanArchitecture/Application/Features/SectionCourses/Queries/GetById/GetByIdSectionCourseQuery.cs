using Application.Features.SectionCourses.Constants;
using Application.Features.SectionCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SectionCourses.Constants.SectionCoursesOperationClaims;

namespace Application.Features.SectionCourses.Queries.GetById;

public class GetByIdSectionCourseQuery : IRequest<GetByIdSectionCourseResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSectionCourseQueryHandler : IRequestHandler<GetByIdSectionCourseQuery, GetByIdSectionCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionCourseRepository _sectionCourseRepository;
        private readonly SectionCourseBusinessRules _sectionCourseBusinessRules;

        public GetByIdSectionCourseQueryHandler(IMapper mapper, ISectionCourseRepository sectionCourseRepository, SectionCourseBusinessRules sectionCourseBusinessRules)
        {
            _mapper = mapper;
            _sectionCourseRepository = sectionCourseRepository;
            _sectionCourseBusinessRules = sectionCourseBusinessRules;
        }

        public async Task<GetByIdSectionCourseResponse> Handle(GetByIdSectionCourseQuery request, CancellationToken cancellationToken)
        {
            SectionCourse? sectionCourse = await _sectionCourseRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionCourseBusinessRules.SectionCourseShouldExistWhenSelected(sectionCourse);



            GetByIdSectionCourseResponse response = _mapper.Map<GetByIdSectionCourseResponse>(sectionCourse);
            return response;
        }
    }
}
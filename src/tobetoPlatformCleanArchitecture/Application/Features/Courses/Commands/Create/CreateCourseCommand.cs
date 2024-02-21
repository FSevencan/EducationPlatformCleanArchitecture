using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommand : IRequest<CreatedCourseResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public double? TotalTime { get; set; }
    public string Name { get; set; }
    

    public string[] Roles => new[] { Admin, instructor, Write, CoursesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourses";

    public ICollection<Guid> SectionIds { get; set; } // burasý null olabilir düþünülür.

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<CreatedCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = _mapper.Map<Course>(request);

            course.SectionCourses = request.SectionIds.Select
                (sectionId => new SectionCourse
                {
                    SectionId = sectionId,
                    CreatedDate = DateTime.Now
                }).ToList();

            await _courseRepository.AddAsync(course);

            CreatedCourseResponse response = _mapper.Map<CreatedCourseResponse>(course);
            return response;
        }
    }
}
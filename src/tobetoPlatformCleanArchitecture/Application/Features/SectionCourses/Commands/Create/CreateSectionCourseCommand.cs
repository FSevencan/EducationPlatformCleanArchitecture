using Application.Features.SectionCourses.Constants;
using Application.Features.SectionCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SectionCourses.Constants.SectionCoursesOperationClaims;

namespace Application.Features.SectionCourses.Commands.Create;

public class CreateSectionCourseCommand : IRequest<CreatedSectionCourseResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
   

    public string[] Roles => new[] { Admin, Write, SectionCoursesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionCourses";

    public class CreateSectionCourseCommandHandler : IRequestHandler<CreateSectionCourseCommand, CreatedSectionCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionCourseRepository _sectionCourseRepository;
        private readonly SectionCourseBusinessRules _sectionCourseBusinessRules;

        public CreateSectionCourseCommandHandler(IMapper mapper, ISectionCourseRepository sectionCourseRepository,
                                         SectionCourseBusinessRules sectionCourseBusinessRules)
        {
            _mapper = mapper;
            _sectionCourseRepository = sectionCourseRepository;
            _sectionCourseBusinessRules = sectionCourseBusinessRules;
        }

        public async Task<CreatedSectionCourseResponse> Handle(CreateSectionCourseCommand request, CancellationToken cancellationToken)
        {
            SectionCourse sectionCourse = _mapper.Map<SectionCourse>(request);

            await _sectionCourseRepository.AddAsync(sectionCourse);

            CreatedSectionCourseResponse response = _mapper.Map<CreatedSectionCourseResponse>(sectionCourse);
            return response;
        }
    }
}
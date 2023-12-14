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

namespace Application.Features.SectionCourses.Commands.Update;

public class UpdateSectionCourseCommand : IRequest<UpdatedSectionCourseResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionCoursesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionCourses";

    public class UpdateSectionCourseCommandHandler : IRequestHandler<UpdateSectionCourseCommand, UpdatedSectionCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionCourseRepository _sectionCourseRepository;
        private readonly SectionCourseBusinessRules _sectionCourseBusinessRules;

        public UpdateSectionCourseCommandHandler(IMapper mapper, ISectionCourseRepository sectionCourseRepository,
                                         SectionCourseBusinessRules sectionCourseBusinessRules)
        {
            _mapper = mapper;
            _sectionCourseRepository = sectionCourseRepository;
            _sectionCourseBusinessRules = sectionCourseBusinessRules;
        }

        public async Task<UpdatedSectionCourseResponse> Handle(UpdateSectionCourseCommand request, CancellationToken cancellationToken)
        {
            SectionCourse? sectionCourse = await _sectionCourseRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionCourseBusinessRules.SectionCourseShouldExistWhenSelected(sectionCourse);
            sectionCourse = _mapper.Map(request, sectionCourse);

            await _sectionCourseRepository.UpdateAsync(sectionCourse!);

            UpdatedSectionCourseResponse response = _mapper.Map<UpdatedSectionCourseResponse>(sectionCourse);
            return response;
        }
    }
}
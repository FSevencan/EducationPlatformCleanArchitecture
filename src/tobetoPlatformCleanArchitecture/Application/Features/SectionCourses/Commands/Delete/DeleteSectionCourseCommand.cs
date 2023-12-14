using Application.Features.SectionCourses.Constants;
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

namespace Application.Features.SectionCourses.Commands.Delete;

public class DeleteSectionCourseCommand : IRequest<DeletedSectionCourseResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SectionCoursesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSectionCourses";

    public class DeleteSectionCourseCommandHandler : IRequestHandler<DeleteSectionCourseCommand, DeletedSectionCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionCourseRepository _sectionCourseRepository;
        private readonly SectionCourseBusinessRules _sectionCourseBusinessRules;

        public DeleteSectionCourseCommandHandler(IMapper mapper, ISectionCourseRepository sectionCourseRepository,
                                         SectionCourseBusinessRules sectionCourseBusinessRules)
        {
            _mapper = mapper;
            _sectionCourseRepository = sectionCourseRepository;
            _sectionCourseBusinessRules = sectionCourseBusinessRules;
        }

        public async Task<DeletedSectionCourseResponse> Handle(DeleteSectionCourseCommand request, CancellationToken cancellationToken)
        {
            SectionCourse? sectionCourse = await _sectionCourseRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionCourseBusinessRules.SectionCourseShouldExistWhenSelected(sectionCourse);

            await _sectionCourseRepository.DeleteAsync(sectionCourse!);

            DeletedSectionCourseResponse response = _mapper.Map<DeletedSectionCourseResponse>(sectionCourse);
            return response;
        }
    }
}
using Application.Features.Likes.Constants;
using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Likes.Constants.LikesOperationClaims;
using Application.Services.Students;
using Application.Services.Sections;
using Application.Features.Students.Rules;
using Application.Features.Sections.Rules;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CreatedLikeResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public Guid SectionId { get; set; }

    public string[] Roles => new[] { Admin, Write, LikesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CreatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly IStudentsService _studentsService;
        private readonly ISectionsService _sectionsService;
        private readonly LikeBusinessRules _likeBusinessRules;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly SectionBusinessRules _sectionBusinessRules;


        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository, LikeBusinessRules likeBusinessRules, IStudentsService studentsService, ISectionsService sectionsService, StudentBusinessRules studentBusinessRules, SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
            _studentsService = studentsService;
            _sectionsService = sectionsService;
            _studentBusinessRules = studentBusinessRules;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<CreatedLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Student student = await _studentsService.GetAsync(u => u.UserId == request.UserId);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            Like like = _mapper.Map<Like>(request);

            like.StudentId = student.Id;
            like.SectionId = request.SectionId;

            await _likeRepository.AddAsync(like);

            Section section = await _sectionsService.GetAsync(s => s.Id == request.SectionId);
            await _sectionBusinessRules.SectionShouldExistWhenSelected(section);

            section.TotalLike += 1;
            await _sectionsService.UpdateAsync(section);

            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
            return response;
        }
    }
}
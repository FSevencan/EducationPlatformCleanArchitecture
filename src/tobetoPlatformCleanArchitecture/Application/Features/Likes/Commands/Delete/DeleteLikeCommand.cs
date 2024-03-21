using Application.Features.Likes.Constants;
using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Likes.Constants.LikesOperationClaims;
using Application.Services.Sections;
using Application.Features.Sections.Rules;

namespace Application.Features.Likes.Commands.Delete;

public class DeleteLikeCommand : IRequest<DeletedLikeResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid SectionId { get; set; }

    public string[] Roles => new[] { Admin, Write, LikesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, DeletedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;
        private readonly ISectionsService _sectionsService;
        private readonly SectionBusinessRules _sectionBusinessRules;

        public DeleteLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository, LikeBusinessRules likeBusinessRules, ISectionsService sectionsService, SectionBusinessRules sectionBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
            _sectionsService = sectionsService;
            _sectionBusinessRules = sectionBusinessRules;
        }

        public async Task<DeletedLikeResponse> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);

            await _likeBusinessRules.LikeShouldExistWhenSelected(like);

            await _likeRepository.DeleteAsync(like!, permanent: true);

            Section section = await _sectionsService.GetAsync(s => s.Id == like.SectionId);
            await _sectionBusinessRules.SectionShouldExistWhenSelected(section);

            section.TotalLike -= 1 ;
            await _sectionsService.UpdateAsync(section);

            DeletedLikeResponse response = _mapper.Map<DeletedLikeResponse>(like);
            return response;
        }
    }
}
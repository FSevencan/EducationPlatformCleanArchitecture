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

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<UpdatedLikeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SectionId { get; set; }
    public bool IsActive { get; set; }
    public Student Student { get; set; }
    public Section Section { get; set; }

    public string[] Roles => new[] { Admin, Write, LikesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, UpdatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public UpdateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<UpdatedLikeResponse> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);
            like = _mapper.Map(request, like);

            await _likeRepository.UpdateAsync(like!);

            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(like);
            return response;
        }
    }
}
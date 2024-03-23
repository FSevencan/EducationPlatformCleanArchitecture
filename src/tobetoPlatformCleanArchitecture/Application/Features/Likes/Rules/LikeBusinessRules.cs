using Application.Features.Likes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Likes.Rules;

public class LikeBusinessRules : BaseBusinessRules
{
    private readonly ILikeRepository _likeRepository;

    public LikeBusinessRules(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public Task LikeShouldExistWhenSelected(Like? like)
    {
        if (like == null)
            throw new BusinessException(LikesBusinessMessages.LikeNotExists);
        return Task.CompletedTask;
    }

    public async Task LikeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Like? like = await _likeRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LikeShouldExistWhenSelected(like);
    }
}
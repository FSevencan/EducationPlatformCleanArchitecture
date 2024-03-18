using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Likes;

public class LikesManager : ILikesService
{
    private readonly ILikeRepository _likeRepository;
    private readonly LikeBusinessRules _likeBusinessRules;

    public LikesManager(ILikeRepository likeRepository, LikeBusinessRules likeBusinessRules)
    {
        _likeRepository = likeRepository;
        _likeBusinessRules = likeBusinessRules;
    }

    public async Task<Like?> GetAsync(
        Expression<Func<Like, bool>> predicate,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Like? like = await _likeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return like;
    }

    public async Task<IPaginate<Like>?> GetListAsync(
        Expression<Func<Like, bool>>? predicate = null,
        Func<IQueryable<Like>, IOrderedQueryable<Like>>? orderBy = null,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Like> likeList = await _likeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return likeList;
    }

    public async Task<Like> AddAsync(Like like)
    {
        Like addedLike = await _likeRepository.AddAsync(like);

        return addedLike;
    }

    public async Task<Like> UpdateAsync(Like like)
    {
        Like updatedLike = await _likeRepository.UpdateAsync(like);

        return updatedLike;
    }

    public async Task<Like> DeleteAsync(Like like, bool permanent = false)
    {
        Like deletedLike = await _likeRepository.DeleteAsync(like);

        return deletedLike;
    }
}

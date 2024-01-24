using Application.Features.MentorshipSessions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MentorshipSessions;

public class MentorshipSessionsManager : IMentorshipSessionsService
{
    private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
    private readonly MentorshipSessionBusinessRules _mentorshipSessionBusinessRules;

    public MentorshipSessionsManager(IMentorshipSessionRepository mentorshipSessionRepository, MentorshipSessionBusinessRules mentorshipSessionBusinessRules)
    {
        _mentorshipSessionRepository = mentorshipSessionRepository;
        _mentorshipSessionBusinessRules = mentorshipSessionBusinessRules;
    }

    public async Task<MentorshipSession?> GetAsync(
        Expression<Func<MentorshipSession, bool>> predicate,
        Func<IQueryable<MentorshipSession>, IIncludableQueryable<MentorshipSession, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MentorshipSession? mentorshipSession = await _mentorshipSessionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return mentorshipSession;
    }

    public async Task<IPaginate<MentorshipSession>?> GetListAsync(
        Expression<Func<MentorshipSession, bool>>? predicate = null,
        Func<IQueryable<MentorshipSession>, IOrderedQueryable<MentorshipSession>>? orderBy = null,
        Func<IQueryable<MentorshipSession>, IIncludableQueryable<MentorshipSession, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MentorshipSession> mentorshipSessionList = await _mentorshipSessionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return mentorshipSessionList;
    }

    public async Task<MentorshipSession> AddAsync(MentorshipSession mentorshipSession)
    {
        MentorshipSession addedMentorshipSession = await _mentorshipSessionRepository.AddAsync(mentorshipSession);

        return addedMentorshipSession;
    }

    public async Task<MentorshipSession> UpdateAsync(MentorshipSession mentorshipSession)
    {
        MentorshipSession updatedMentorshipSession = await _mentorshipSessionRepository.UpdateAsync(mentorshipSession);

        return updatedMentorshipSession;
    }

    public async Task<MentorshipSession> DeleteAsync(MentorshipSession mentorshipSession, bool permanent = false)
    {
        MentorshipSession deletedMentorshipSession = await _mentorshipSessionRepository.DeleteAsync(mentorshipSession);

        return deletedMentorshipSession;
    }
}

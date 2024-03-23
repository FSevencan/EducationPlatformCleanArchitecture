using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MentorshipSessions;

public interface IMentorshipSessionsService
{
    Task<MentorshipSession?> GetAsync(
        Expression<Func<MentorshipSession, bool>> predicate,
        Func<IQueryable<MentorshipSession>, IIncludableQueryable<MentorshipSession, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MentorshipSession>?> GetListAsync(
        Expression<Func<MentorshipSession, bool>>? predicate = null,
        Func<IQueryable<MentorshipSession>, IOrderedQueryable<MentorshipSession>>? orderBy = null,
        Func<IQueryable<MentorshipSession>, IIncludableQueryable<MentorshipSession, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MentorshipSession> AddAsync(MentorshipSession mentorshipSession);
    Task<MentorshipSession> UpdateAsync(MentorshipSession mentorshipSession);
    Task<MentorshipSession> DeleteAsync(MentorshipSession mentorshipSession, bool permanent = false);
}

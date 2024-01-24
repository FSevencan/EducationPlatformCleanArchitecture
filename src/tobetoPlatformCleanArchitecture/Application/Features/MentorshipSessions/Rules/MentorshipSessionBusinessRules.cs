using Application.Features.MentorshipSessions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.MentorshipSessions.Rules;

public class MentorshipSessionBusinessRules : BaseBusinessRules
{
    private readonly IMentorshipSessionRepository _mentorshipSessionRepository;

    public MentorshipSessionBusinessRules(IMentorshipSessionRepository mentorshipSessionRepository)
    {
        _mentorshipSessionRepository = mentorshipSessionRepository;
    }

    public Task MentorshipSessionShouldExistWhenSelected(MentorshipSession? mentorshipSession)
    {
        if (mentorshipSession == null)
            throw new BusinessException(MentorshipSessionsBusinessMessages.MentorshipSessionNotExists);
        return Task.CompletedTask;
    }

    public async Task MentorshipSessionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MentorshipSession? mentorshipSession = await _mentorshipSessionRepository.GetAsync(
            predicate: ms => ms.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MentorshipSessionShouldExistWhenSelected(mentorshipSession);
    }
}
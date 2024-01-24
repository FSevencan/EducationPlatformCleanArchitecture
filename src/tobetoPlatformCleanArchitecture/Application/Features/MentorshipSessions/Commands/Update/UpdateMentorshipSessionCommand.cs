using Application.Features.MentorshipSessions.Constants;
using Application.Features.MentorshipSessions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MentorshipSessions.Constants.MentorshipSessionsOperationClaims;

namespace Application.Features.MentorshipSessions.Commands.Update;

public class UpdateMentorshipSessionCommand : IRequest<UpdatedMentorshipSessionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }

    public string[] Roles => new[] { Admin, Write, MentorshipSessionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMentorshipSessions";

    public class UpdateMentorshipSessionCommandHandler : IRequestHandler<UpdateMentorshipSessionCommand, UpdatedMentorshipSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
        private readonly MentorshipSessionBusinessRules _mentorshipSessionBusinessRules;

        public UpdateMentorshipSessionCommandHandler(IMapper mapper, IMentorshipSessionRepository mentorshipSessionRepository,
                                         MentorshipSessionBusinessRules mentorshipSessionBusinessRules)
        {
            _mapper = mapper;
            _mentorshipSessionRepository = mentorshipSessionRepository;
            _mentorshipSessionBusinessRules = mentorshipSessionBusinessRules;
        }

        public async Task<UpdatedMentorshipSessionResponse> Handle(UpdateMentorshipSessionCommand request, CancellationToken cancellationToken)
        {
            MentorshipSession? mentorshipSession = await _mentorshipSessionRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _mentorshipSessionBusinessRules.MentorshipSessionShouldExistWhenSelected(mentorshipSession);
            mentorshipSession = _mapper.Map(request, mentorshipSession);

            await _mentorshipSessionRepository.UpdateAsync(mentorshipSession!);

            UpdatedMentorshipSessionResponse response = _mapper.Map<UpdatedMentorshipSessionResponse>(mentorshipSession);
            return response;
        }
    }
}
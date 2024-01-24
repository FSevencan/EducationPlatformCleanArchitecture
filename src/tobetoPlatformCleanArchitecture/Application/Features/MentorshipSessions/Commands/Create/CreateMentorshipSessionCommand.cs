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

namespace Application.Features.MentorshipSessions.Commands.Create;

public class CreateMentorshipSessionCommand : IRequest<CreatedMentorshipSessionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }

    public string[] Roles => new[] { Admin, Write, MentorshipSessionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMentorshipSessions";

    public class CreateMentorshipSessionCommandHandler : IRequestHandler<CreateMentorshipSessionCommand, CreatedMentorshipSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
        private readonly MentorshipSessionBusinessRules _mentorshipSessionBusinessRules;

        public CreateMentorshipSessionCommandHandler(IMapper mapper, IMentorshipSessionRepository mentorshipSessionRepository,
                                         MentorshipSessionBusinessRules mentorshipSessionBusinessRules)
        {
            _mapper = mapper;
            _mentorshipSessionRepository = mentorshipSessionRepository;
            _mentorshipSessionBusinessRules = mentorshipSessionBusinessRules;
        }

        public async Task<CreatedMentorshipSessionResponse> Handle(CreateMentorshipSessionCommand request, CancellationToken cancellationToken)
        {
            MentorshipSession mentorshipSession = _mapper.Map<MentorshipSession>(request);

            await _mentorshipSessionRepository.AddAsync(mentorshipSession);

            CreatedMentorshipSessionResponse response = _mapper.Map<CreatedMentorshipSessionResponse>(mentorshipSession);
            return response;
        }
    }
}
using Application.Features.MentorshipSessions.Constants;
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

namespace Application.Features.MentorshipSessions.Commands.Delete;

public class DeleteMentorshipSessionCommand : IRequest<DeletedMentorshipSessionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, MentorshipSessionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMentorshipSessions";

    public class DeleteMentorshipSessionCommandHandler : IRequestHandler<DeleteMentorshipSessionCommand, DeletedMentorshipSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
        private readonly MentorshipSessionBusinessRules _mentorshipSessionBusinessRules;

        public DeleteMentorshipSessionCommandHandler(IMapper mapper, IMentorshipSessionRepository mentorshipSessionRepository,
                                         MentorshipSessionBusinessRules mentorshipSessionBusinessRules)
        {
            _mapper = mapper;
            _mentorshipSessionRepository = mentorshipSessionRepository;
            _mentorshipSessionBusinessRules = mentorshipSessionBusinessRules;
        }

        public async Task<DeletedMentorshipSessionResponse> Handle(DeleteMentorshipSessionCommand request, CancellationToken cancellationToken)
        {
            MentorshipSession? mentorshipSession = await _mentorshipSessionRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _mentorshipSessionBusinessRules.MentorshipSessionShouldExistWhenSelected(mentorshipSession);

            await _mentorshipSessionRepository.DeleteAsync(mentorshipSession!);

            DeletedMentorshipSessionResponse response = _mapper.Map<DeletedMentorshipSessionResponse>(mentorshipSession);
            return response;
        }
    }
}
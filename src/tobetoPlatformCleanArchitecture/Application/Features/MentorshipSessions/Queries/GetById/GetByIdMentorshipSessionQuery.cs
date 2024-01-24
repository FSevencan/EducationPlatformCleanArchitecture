using Application.Features.MentorshipSessions.Constants;
using Application.Features.MentorshipSessions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MentorshipSessions.Constants.MentorshipSessionsOperationClaims;

namespace Application.Features.MentorshipSessions.Queries.GetById;

public class GetByIdMentorshipSessionQuery : IRequest<GetByIdMentorshipSessionResponse>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdMentorshipSessionQueryHandler : IRequestHandler<GetByIdMentorshipSessionQuery, GetByIdMentorshipSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
        private readonly MentorshipSessionBusinessRules _mentorshipSessionBusinessRules;

        public GetByIdMentorshipSessionQueryHandler(IMapper mapper, IMentorshipSessionRepository mentorshipSessionRepository, MentorshipSessionBusinessRules mentorshipSessionBusinessRules)
        {
            _mapper = mapper;
            _mentorshipSessionRepository = mentorshipSessionRepository;
            _mentorshipSessionBusinessRules = mentorshipSessionBusinessRules;
        }

        public async Task<GetByIdMentorshipSessionResponse> Handle(GetByIdMentorshipSessionQuery request, CancellationToken cancellationToken)
        {
            MentorshipSession? mentorshipSession = await _mentorshipSessionRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _mentorshipSessionBusinessRules.MentorshipSessionShouldExistWhenSelected(mentorshipSession);

            GetByIdMentorshipSessionResponse response = _mapper.Map<GetByIdMentorshipSessionResponse>(mentorshipSession);
            return response;
        }
    }
}
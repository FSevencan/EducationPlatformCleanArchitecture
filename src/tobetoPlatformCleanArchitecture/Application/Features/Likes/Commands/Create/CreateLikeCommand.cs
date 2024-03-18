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
using Microsoft.AspNetCore.Http;
using Core.Security.Extensions;
using Application.Services.Students;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CreatedLikeResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public Guid SectionId { get; set; }
    
    public string[] Roles => new[] { Admin, Write, LikesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CreatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;
        private readonly IStudentsService _studentsService;


        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules, IStudentsService studentsService)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
            _studentsService = studentsService;
        }

        public async Task<CreatedLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Student student = await _studentsService.GetAsync(u => u.UserId == request.UserId);

            Like like = _mapper.Map<Like>(request);

            like.StudentId = student.Id;
            like.SectionId = request.SectionId;

            await _likeRepository.AddAsync(like);

            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
            return response;
        }
    }
}
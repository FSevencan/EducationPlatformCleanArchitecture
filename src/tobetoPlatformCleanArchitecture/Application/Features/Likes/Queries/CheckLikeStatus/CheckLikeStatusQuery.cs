using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using Application.Services.Students;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Likes.Constants.LikesOperationClaims;


namespace Application.Features.Likes.Queries.CheckLikeStatus;

public class CheckLikeStatusQuery : IRequest<CheckLikeStatusResponse>/*, ISecuredRequest*/
{
    public int UserId { get; set; }
    public Guid SectionId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class CheckLikeStatusQueryHandler : IRequestHandler<CheckLikeStatusQuery, CheckLikeStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly IStudentsService _studentsService;
        private readonly LikeBusinessRules _likeBusinessRules;

        public CheckLikeStatusQueryHandler(IMapper mapper, ILikeRepository likeRepository, IStudentsService studentsService, LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _studentsService = studentsService;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CheckLikeStatusResponse> Handle(CheckLikeStatusQuery request, CancellationToken cancellationToken)
        {
            Student student = await _studentsService.GetAsync(u => u.UserId == request.UserId);

            Like? like = await _likeRepository.GetAsync(predicate: l => l.StudentId == student.Id && l.SectionId == request.SectionId , cancellationToken: cancellationToken);

            CheckLikeStatusResponse response = _mapper.Map<CheckLikeStatusResponse>(like);
            return response;
        }
    }
}

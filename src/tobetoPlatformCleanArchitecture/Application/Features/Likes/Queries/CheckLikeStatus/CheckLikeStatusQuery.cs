using Application.Features.Students.Rules;
using Application.Services.Repositories;
using Application.Services.Students;
using Domain.Entities;
using MediatR;
using static Application.Features.Likes.Constants.LikesOperationClaims;

namespace Application.Features.Likes.Queries.CheckLikeStatus;

public class CheckLikeStatusQuery : IRequest<CheckLikeStatusResponse>
{
    public int UserId { get; set; }
    public Guid SectionId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class CheckLikeStatusQueryHandler : IRequestHandler<CheckLikeStatusQuery, CheckLikeStatusResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IStudentsService _studentsService;
        private readonly StudentBusinessRules _studentBusinessRules;


        public CheckLikeStatusQueryHandler(ILikeRepository likeRepository, IStudentsService studentsService, StudentBusinessRules studentBusinessRules)
        {
            _likeRepository = likeRepository;
            _studentsService = studentsService;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CheckLikeStatusResponse> Handle(CheckLikeStatusQuery request, CancellationToken cancellationToken)
        {
            Student student = await _studentsService.GetAsync(u => u.UserId == request.UserId);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            Like? like = await _likeRepository.GetAsync(predicate: l => l.StudentId == student.Id && l.SectionId == request.SectionId, cancellationToken: cancellationToken);

            var response = new CheckLikeStatusResponse
            {
                IsLiked = like != null,
                Id = like?.Id
            };
            return response;
        }
    }
}

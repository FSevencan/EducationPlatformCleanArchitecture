using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Security.Extensions;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByInstructorLockUserIdQuery : IRequest<GetByIdInstructorLockResponse>
{
    public int UserId { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdInstructoLockUserIdQueryHandler : IRequestHandler<GetByInstructorLockUserIdQuery, GetByIdInstructorLockResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public GetByIdInstructoLockUserIdQueryHandler(IMapper mapper, IInstructorRepository instructorRepository, InstructorBusinessRules instructorBusinessRules, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetByIdInstructorLockResponse> Handle(GetByInstructorLockUserIdQuery request, CancellationToken cancellationToken)
        {
            
            Instructor? instructor = await _instructorRepository.GetAsync(
                predicate: s => s.User.Id == request.UserId,
                include: i => i
                .Include(section => section.SectionInstructors).ThenInclude(si=>si.Section)
               .Include(user => user.User),
                cancellationToken: cancellationToken);

            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            GetByIdInstructorLockResponse response = _mapper.Map<GetByIdInstructorLockResponse>(instructor);
            return response;
        }
    }
}
using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByInstructorUserIdQuery : IRequest<GetByIdInstructorResponse>/*, ISecuredRequest*/
{
    public int UserId { get; set; }


    public string[] Roles => new[] { Admin, Read };

    public class GetByIdInstructorQueryHandler : IRequestHandler<GetByInstructorUserIdQuery, GetByIdInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public GetByIdInstructorQueryHandler(IMapper mapper, IInstructorRepository instructorRepository, InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<GetByIdInstructorResponse> Handle(GetByInstructorUserIdQuery request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(
                predicate: s => s.User.Id == request.UserId,
                include: i => i.Include(user => user.User)
                .Include(section => section.SectionInstructors)
                .ThenInclude(x => x.Section)
                .ThenInclude(s => s.SectionCourses)
                .ThenInclude(sc => sc.Course)
                .ThenInclude(s => s.SectionCourses)
                .ThenInclude(x => x.Section)
                .ThenInclude(x => x.Category),
                cancellationToken: cancellationToken);

            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return response;
        }
    }
}
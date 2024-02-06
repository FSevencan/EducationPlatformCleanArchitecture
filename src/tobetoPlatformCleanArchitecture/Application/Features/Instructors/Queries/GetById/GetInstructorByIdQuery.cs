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

public class GetInstructorByIdQuery : IRequest<GetByIdInstructorResponse>/*, ISecuredRequest*/
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdInstructorQueryHandler : IRequestHandler<GetInstructorByIdQuery, GetByIdInstructorResponse>
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

        public async Task<GetByIdInstructorResponse> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(

               predicate: s => s.Id == request.Id,
                include: i => i
                .Include(section => section.SectionInstructors)
                .ThenInclude(x => x.Section)
                .ThenInclude(x => x.Category)
                .Include(section => section.SectionInstructors)
                .ThenInclude(x => x.Section).ThenInclude(s => s.SectionCourses).ThenInclude(sc => sc.Course)
               .Include(user => user.User),
                cancellationToken: cancellationToken);

            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return response;
        }
    }
}
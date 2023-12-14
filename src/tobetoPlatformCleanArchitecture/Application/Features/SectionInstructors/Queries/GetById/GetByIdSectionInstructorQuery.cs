using Application.Features.SectionInstructors.Constants;
using Application.Features.SectionInstructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SectionInstructors.Constants.SectionInstructorsOperationClaims;

namespace Application.Features.SectionInstructors.Queries.GetById;

public class GetByIdSectionInstructorQuery : IRequest<GetByIdSectionInstructorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSectionInstructorQueryHandler : IRequestHandler<GetByIdSectionInstructorQuery, GetByIdSectionInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionInstructorRepository _sectionInstructorRepository;
        private readonly SectionInstructorBusinessRules _sectionInstructorBusinessRules;

        public GetByIdSectionInstructorQueryHandler(IMapper mapper, ISectionInstructorRepository sectionInstructorRepository, SectionInstructorBusinessRules sectionInstructorBusinessRules)
        {
            _mapper = mapper;
            _sectionInstructorRepository = sectionInstructorRepository;
            _sectionInstructorBusinessRules = sectionInstructorBusinessRules;
        }

        public async Task<GetByIdSectionInstructorResponse> Handle(GetByIdSectionInstructorQuery request, CancellationToken cancellationToken)
        {
            SectionInstructor? sectionInstructor = await _sectionInstructorRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _sectionInstructorBusinessRules.SectionInstructorShouldExistWhenSelected(sectionInstructor);

            GetByIdSectionInstructorResponse response = _mapper.Map<GetByIdSectionInstructorResponse>(sectionInstructor);
            return response;
        }
    }
}
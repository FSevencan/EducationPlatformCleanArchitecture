using Application.Features.StudentSections.Constants;
using Application.Features.StudentSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentSections.Constants.StudentSectionsOperationClaims;

namespace Application.Features.StudentSections.Queries.GetById;

public class GetByIdStudentSectionQuery : IRequest<GetByIdStudentSectionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentSectionQueryHandler : IRequestHandler<GetByIdStudentSectionQuery, GetByIdStudentSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSectionRepository _studentSectionRepository;
        private readonly StudentSectionBusinessRules _studentSectionBusinessRules;

        public GetByIdStudentSectionQueryHandler(IMapper mapper, IStudentSectionRepository studentSectionRepository, StudentSectionBusinessRules studentSectionBusinessRules)
        {
            _mapper = mapper;
            _studentSectionRepository = studentSectionRepository;
            _studentSectionBusinessRules = studentSectionBusinessRules;
        }

        public async Task<GetByIdStudentSectionResponse> Handle(GetByIdStudentSectionQuery request, CancellationToken cancellationToken)
        {
            StudentSection? studentSection = await _studentSectionRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSectionBusinessRules.StudentSectionShouldExistWhenSelected(studentSection);

            GetByIdStudentSectionResponse response = _mapper.Map<GetByIdStudentSectionResponse>(studentSection);
            return response;
        }
    }
}
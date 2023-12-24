using Application.Features.ClassRoomTypeSections.Constants;
using Application.Features.ClassRoomTypeSections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ClassRoomTypeSections.Constants.ClassRoomTypeSectionsOperationClaims;

namespace Application.Features.ClassRoomTypeSections.Queries.GetById;

public class GetByIdClassRoomTypeSectionQuery : IRequest<GetByIdClassRoomTypeSectionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdClassRoomTypeSectionQueryHandler : IRequestHandler<GetByIdClassRoomTypeSectionQuery, GetByIdClassRoomTypeSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
        private readonly ClassRoomTypeSectionBusinessRules _classRoomTypeSectionBusinessRules;

        public GetByIdClassRoomTypeSectionQueryHandler(IMapper mapper, IClassRoomTypeSectionRepository classRoomTypeSectionRepository, ClassRoomTypeSectionBusinessRules classRoomTypeSectionBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
            _classRoomTypeSectionBusinessRules = classRoomTypeSectionBusinessRules;
        }

        public async Task<GetByIdClassRoomTypeSectionResponse> Handle(GetByIdClassRoomTypeSectionQuery request, CancellationToken cancellationToken)
        {
            ClassRoomTypeSection? classRoomTypeSection = await _classRoomTypeSectionRepository.GetAsync(predicate: crts => crts.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomTypeSectionBusinessRules.ClassRoomTypeSectionShouldExistWhenSelected(classRoomTypeSection);

            GetByIdClassRoomTypeSectionResponse response = _mapper.Map<GetByIdClassRoomTypeSectionResponse>(classRoomTypeSection);
            return response;
        }
    }
}
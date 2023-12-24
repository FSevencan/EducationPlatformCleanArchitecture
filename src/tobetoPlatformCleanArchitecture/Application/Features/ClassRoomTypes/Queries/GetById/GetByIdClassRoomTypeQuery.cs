using Application.Features.ClassRoomTypes.Constants;
using Application.Features.ClassRoomTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ClassRoomTypes.Constants.ClassRoomTypesOperationClaims;

namespace Application.Features.ClassRoomTypes.Queries.GetById;

public class GetByIdClassRoomTypeQuery : IRequest<GetByIdClassRoomTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdClassRoomTypeQueryHandler : IRequestHandler<GetByIdClassRoomTypeQuery, GetByIdClassRoomTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomTypeRepository _classRoomTypeRepository;
        private readonly ClassRoomTypeBusinessRules _classRoomTypeBusinessRules;

        public GetByIdClassRoomTypeQueryHandler(IMapper mapper, IClassRoomTypeRepository classRoomTypeRepository, ClassRoomTypeBusinessRules classRoomTypeBusinessRules)
        {
            _mapper = mapper;
            _classRoomTypeRepository = classRoomTypeRepository;
            _classRoomTypeBusinessRules = classRoomTypeBusinessRules;
        }

        public async Task<GetByIdClassRoomTypeResponse> Handle(GetByIdClassRoomTypeQuery request, CancellationToken cancellationToken)
        {
            ClassRoomType? classRoomType = await _classRoomTypeRepository.GetAsync(predicate: crt => crt.Id == request.Id, cancellationToken: cancellationToken);
            await _classRoomTypeBusinessRules.ClassRoomTypeShouldExistWhenSelected(classRoomType);

            GetByIdClassRoomTypeResponse response = _mapper.Map<GetByIdClassRoomTypeResponse>(classRoomType);
            return response;
        }
    }
}
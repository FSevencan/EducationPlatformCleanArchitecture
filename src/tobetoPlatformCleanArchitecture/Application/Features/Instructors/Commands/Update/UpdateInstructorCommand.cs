using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;
using Core.Security.Entities;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommand : IRequest<UpdatedInstructorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string About { get; set; }
    public string Title { get; set; }
   

    public string[] Roles => new[] { Admin, Write, InstructorsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetInstructors";

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, UpdatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public UpdateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<UpdatedInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);
            instructor = _mapper.Map(request, instructor);

            await _instructorRepository.UpdateAsync(instructor!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}
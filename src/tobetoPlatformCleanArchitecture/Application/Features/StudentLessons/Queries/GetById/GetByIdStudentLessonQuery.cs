using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentLessons.Queries.GetById;

public class GetByIdStudentLessonQuery : IRequest<GetByIdStudentLessonResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentLessonQueryHandler : IRequestHandler<GetByIdStudentLessonQuery, GetByIdStudentLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public GetByIdStudentLessonQueryHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository, StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<GetByIdStudentLessonResponse> Handle(GetByIdStudentLessonQuery request, CancellationToken cancellationToken)
        {
            StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentLessonBusinessRules.StudentLessonShouldExistWhenSelected(studentLesson);

            GetByIdStudentLessonResponse response = _mapper.Map<GetByIdStudentLessonResponse>(studentLesson);
            return response;
        }
    }
}
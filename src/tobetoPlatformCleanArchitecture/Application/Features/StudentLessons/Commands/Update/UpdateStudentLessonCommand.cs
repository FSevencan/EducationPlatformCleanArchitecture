using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentLessons.Commands.Update;

public class UpdateStudentLessonCommand : IRequest<UpdatedStudentLessonResponse>
{
    public Guid Id { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsCompleted { get; set; }


    public class UpdateStudentLessonCommandHandler : IRequestHandler<UpdateStudentLessonCommand, UpdatedStudentLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public UpdateStudentLessonCommandHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository,
                                         StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<UpdatedStudentLessonResponse> Handle(UpdateStudentLessonCommand request, CancellationToken cancellationToken)
        {
            StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentLessonBusinessRules.StudentLessonShouldExistWhenSelected(studentLesson);
            studentLesson = _mapper.Map(request, studentLesson);

            await _studentLessonRepository.UpdateAsync(studentLesson!);

            UpdatedStudentLessonResponse response = _mapper.Map<UpdatedStudentLessonResponse>(studentLesson);
            return response;
        }
    }
}
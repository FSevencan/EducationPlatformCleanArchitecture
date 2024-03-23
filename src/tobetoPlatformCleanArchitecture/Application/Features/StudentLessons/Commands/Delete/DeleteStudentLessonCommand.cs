using Application.Features.StudentLessons.Constants;
using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentLessons.Commands.Delete;

public class DeleteStudentLessonCommand : IRequest<DeletedStudentLessonResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentLessonCommandHandler : IRequestHandler<DeleteStudentLessonCommand, DeletedStudentLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public DeleteStudentLessonCommandHandler(IMapper mapper, IStudentLessonRepository studentLessonRepository,
                                         StudentLessonBusinessRules studentLessonBusinessRules)
        {
            _mapper = mapper;
            _studentLessonRepository = studentLessonRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<DeletedStudentLessonResponse> Handle(DeleteStudentLessonCommand request, CancellationToken cancellationToken)
        {
            StudentLesson? studentLesson = await _studentLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentLessonBusinessRules.StudentLessonShouldExistWhenSelected(studentLesson);

            await _studentLessonRepository.DeleteAsync(studentLesson!);

            DeletedStudentLessonResponse response = _mapper.Map<DeletedStudentLessonResponse>(studentLesson);
            return response;
        }
    }
}
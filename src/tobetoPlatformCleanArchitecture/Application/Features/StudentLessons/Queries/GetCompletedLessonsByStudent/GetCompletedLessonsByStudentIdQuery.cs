using Application.Features.StudentLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentLessons.Queries.GetCompletedLessonsByStudent;
public class GetCompletedLessonsByStudentIdQuery : IRequest<List<GetCompletedLessonDto>>
{
    public int UserId { get; set; }

    public class GetCompletedLessonsByStudentIdQueryHandler : IRequestHandler<GetCompletedLessonsByStudentIdQuery, List<GetCompletedLessonDto>>
    {
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentLessonBusinessRules _studentLessonBusinessRules;

        public GetCompletedLessonsByStudentIdQueryHandler(IStudentLessonRepository studentLessonRepository, IStudentRepository studentRepository, StudentLessonBusinessRules studentLessonBusinessRules, IMapper mapper)
        {
            _studentLessonRepository = studentLessonRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentLessonBusinessRules = studentLessonBusinessRules;
        }

        public async Task<List<GetCompletedLessonDto>> Handle(GetCompletedLessonsByStudentIdQuery request, CancellationToken cancellationToken)
        {
            Student student = await _studentLessonBusinessRules.CheckIfStudentExists(request.UserId, cancellationToken);

            // Öğrencinin tamamladığı dersleri al
            var completedLessons = await _studentLessonRepository.GetAll(
                lesson => lesson.StudentId == student.Id && lesson.IsCompleted
            );

            // Elde edilen dersleri DTO'ya dönüştür ve listeyi döndür
            List<GetCompletedLessonDto> response = completedLessons
                .Select(lesson => _mapper.Map<GetCompletedLessonDto>(lesson))
                .ToList();

            return response;
        }
    }
}
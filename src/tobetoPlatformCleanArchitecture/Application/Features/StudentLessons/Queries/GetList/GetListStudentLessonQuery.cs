using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentLessons.Queries.GetList;

public class GetListStudentLessonQuery : IRequest<GetListResponse<GetListStudentLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentLessonQueryHandler : IRequestHandler<GetListStudentLessonQuery, GetListResponse<GetListStudentLessonListItemDto>>
    {
        private readonly IStudentLessonRepository _studentLessonRepository;
        private readonly IMapper _mapper;

        public GetListStudentLessonQueryHandler(IStudentLessonRepository studentLessonRepository, IMapper mapper)
        {
            _studentLessonRepository = studentLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentLessonListItemDto>> Handle(GetListStudentLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentLesson> studentLessons = await _studentLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentLessonListItemDto> response = _mapper.Map<GetListResponse<GetListStudentLessonListItemDto>>(studentLessons);
            return response;
        }
    }
}
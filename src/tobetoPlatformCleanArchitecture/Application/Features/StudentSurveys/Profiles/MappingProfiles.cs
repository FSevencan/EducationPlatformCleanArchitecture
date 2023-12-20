using Application.Features.StudentSurveys.Commands.Create;
using Application.Features.StudentSurveys.Commands.Delete;
using Application.Features.StudentSurveys.Commands.Update;
using Application.Features.StudentSurveys.Queries.GetById;
using Application.Features.StudentSurveys.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentSurveys.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentSurvey, CreateStudentSurveyCommand>().ReverseMap();
        CreateMap<StudentSurvey, CreatedStudentSurveyResponse>().ReverseMap();
        CreateMap<StudentSurvey, UpdateStudentSurveyCommand>().ReverseMap();
        CreateMap<StudentSurvey, UpdatedStudentSurveyResponse>().ReverseMap();
        CreateMap<StudentSurvey, DeleteStudentSurveyCommand>().ReverseMap();
        CreateMap<StudentSurvey, DeletedStudentSurveyResponse>().ReverseMap();
        CreateMap<StudentSurvey, GetByIdStudentSurveyResponse>().ReverseMap();
        CreateMap<StudentSurvey, GetListStudentSurveyListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentSurvey>, GetListResponse<GetListStudentSurveyListItemDto>>().ReverseMap();
    }
}
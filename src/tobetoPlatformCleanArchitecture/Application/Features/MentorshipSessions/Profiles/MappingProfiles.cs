using Application.Features.MentorshipSessions.Commands.Create;
using Application.Features.MentorshipSessions.Commands.Delete;
using Application.Features.MentorshipSessions.Commands.Update;
using Application.Features.MentorshipSessions.Queries.GetById;
using Application.Features.MentorshipSessions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.MentorshipSessions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MentorshipSession, CreateMentorshipSessionCommand>().ReverseMap();
        CreateMap<MentorshipSession, CreatedMentorshipSessionResponse>().ReverseMap();
        CreateMap<MentorshipSession, UpdateMentorshipSessionCommand>().ReverseMap();
        CreateMap<MentorshipSession, UpdatedMentorshipSessionResponse>().ReverseMap();
        CreateMap<MentorshipSession, DeleteMentorshipSessionCommand>().ReverseMap();
        CreateMap<MentorshipSession, DeletedMentorshipSessionResponse>().ReverseMap();
        CreateMap<MentorshipSession, GetByIdMentorshipSessionResponse>().ReverseMap();
        CreateMap<MentorshipSession, GetListMentorshipSessionListItemDto>().ReverseMap();
        CreateMap<IPaginate<MentorshipSession>, GetListResponse<GetListMentorshipSessionListItemDto>>().ReverseMap();
    }
}
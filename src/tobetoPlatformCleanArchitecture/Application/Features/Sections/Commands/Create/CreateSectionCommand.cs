using Application.Features.Sections.Constants;
using Application.Features.Sections.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sections.Constants.SectionsOperationClaims;
using MailKit;
using Core.Mailing;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Sections.Commands.Create;

public class CreateSectionCommand : IRequest<CreatedSectionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public ICollection<int>? InstructorIds { get; set; }
    public ICollection<Guid>? CourseIds { get; set; }
    public ICollection<Guid>? ClassRoomTypeIds { get; set; }


    public string[] Roles => new[] { Admin, instructor, Write, SectionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSections";

    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, CreatedSectionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionBusinessRules _sectionBusinessRules;
        private readonly Core.Mailing.IMailService _mailService;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ILogger<CreateSectionCommandHandler> _logger;

        public CreateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository,
                                         SectionBusinessRules sectionBusinessRules, ILogger<CreateSectionCommandHandler> logger, Core.Mailing.IMailService mailService, ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _sectionBusinessRules = sectionBusinessRules;
            _mailService = mailService;
            _subscriptionRepository = subscriptionRepository;
            _logger = logger;
        }

        public async Task<CreatedSectionResponse> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            Section section = _mapper.Map<Section>(request);

            section.SectionInstructors = request.InstructorIds.Select(instructorId => new SectionInstructor
            {
                InstructorId = instructorId,
                CreatedDate = DateTime.Now,
            }).ToList();

            section.ClassRoomTypeSection = request.ClassRoomTypeIds.Select(classRoomTypeId => new ClassRoomTypeSection
            {
                ClassRoomTypeId = classRoomTypeId,
                CreatedDate = DateTime.Now,
            }).ToList();

            section.SectionCourses = request.CourseIds.Select(courseId => new SectionCourse
            {
                CourseId = courseId,
                CreatedDate = DateTime.Now,
            }).ToList();

            await _sectionRepository.AddAsync(section);

            // Yeni eklenen section için abonelere e-posta gönder
            var subscriptionsForClassRoomType = await _subscriptionRepository.GetListAsync(
            include: u => u.Include(user => user.User),
            predicate: sub => request.ClassRoomTypeIds.Contains(sub.ClassRoomTypeId) && sub.DeletedDate == null
            );

            // E-posta gönderilecek abonelikler filtreleniyor
            var activeSubscriptions = subscriptionsForClassRoomType.Items
                .Where(sub => sub.DeletedDate == null)
                .ToList();

            // Sadece aktif abonelere e-posta gönderiliyor
            await _mailService.SendSectionCreatedEmailAsync(activeSubscriptions, section);


            CreatedSectionResponse response = _mapper.Map<CreatedSectionResponse>(section);
            return response;
        }
    }
}
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Announcements;
using Application.Services.ApplicationEducations;
using Application.Services.Categories;
using Application.Services.Certificates;
using Application.Services.ClassRooms;
using Application.Services.Courses;
using Application.Services.Exams;
using Application.Services.Instructors;
using Application.Services.Languages;
using Application.Services.Lessons;
using Application.Services.ProducerCompanies;
using Application.Services.Sections;
using Application.Services.SectionAbouts;
using Application.Services.SectionCourses;
using Application.Services.SectionInstructors;
using Application.Services.Skills;
using Application.Services.Students;
using Application.Services.StudentClassRooms;
using Application.Services.ClassRoomTypes;
using Application.Services.ClassRoomTypeSections;
using Application.Services.MentorshipSessions;
using Application.Services.CampusEncounters;
using Application.Services.StudentLessons;
using Application.Services.Choices;
using Application.Services.Questions;
using Application.Services.UserAnswers;

using Application.Services.StudentSkills;

using Application.Services.Surveys;




namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
        services.AddScoped<IApplicationEducationsService, ApplicationEducationsManager>();
        services.AddScoped<ICategoriesService, CategoriesManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<IClassRoomsService, ClassRoomsManager>();
        services.AddScoped<ICoursesService, CoursesManager>();
        services.AddScoped<IExamsService, ExamsManager>();
        services.AddScoped<IInstructorsService, InstructorsManager>();
        services.AddScoped<ILanguagesService, LanguagesManager>();
        services.AddScoped<ILessonsService, LessonsManager>();
        services.AddScoped<IProducerCompaniesService, ProducerCompaniesManager>();
        services.AddScoped<ISectionsService, SectionsManager>();
        services.AddScoped<ISectionAboutsService, SectionAboutsManager>();
        services.AddScoped<ISectionCoursesService, SectionCoursesManager>();
        services.AddScoped<ISectionInstructorsService, SectionInstructorsManager>();
        services.AddScoped<ISkillsService, SkillsManager>();
        services.AddScoped<IStudentsService, StudentsManager>();
        services.AddScoped<IStudentClassRoomsService, StudentClassRoomsManager>();
     
        services.AddScoped<IStudentSkillsService, StudentSkillsManager>();
  
        services.AddScoped<ISurveysService, SurveysManager>();
        services.AddScoped<IClassRoomsService, ClassRoomsManager>();
        services.AddScoped<IClassRoomTypesService, ClassRoomTypesManager>();
        services.AddScoped<IClassRoomTypeSectionsService, ClassRoomTypeSectionsManager>();
        services.AddScoped<ICategoriesService, CategoriesManager>();
     services.AddScoped<IMentorshipSessionsService, MentorshipSessionsManager>();
     services.AddScoped<ICampusEncountersService, CampusEncountersManager>();
  services.AddScoped<ILessonsService, LessonsManager>();
  services.AddScoped<IExamsService, ExamsManager>();
  services.AddScoped<ISectionAboutsService, SectionAboutsManager>();
  services.AddScoped<IClassRoomTypesService, ClassRoomTypesManager>();
  services.AddScoped<ISurveysService, SurveysManager>();
  services.AddScoped<IStudentLessonsService, StudentLessonsManager>();
  services.AddScoped<IChoicesService, ChoicesManager>();
  services.AddScoped<IQuestionsService, QuestionsManager>();
  services.AddScoped<IUserAnswersService, UserAnswersManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
